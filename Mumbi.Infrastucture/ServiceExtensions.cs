using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Mumbi.Application.Interfaces;
using Mumbi.Application.Wrappers;
using Mumbi.Domain.Settings;
using Mumbi.Infrastucture.Context;
using Mumbi.Infrastucture.Repositories;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace Mumbi.Infrastucture
{
    public static class ServiceExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(option =>
                    option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                   b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));

            var pathToKey = Path.Combine(Directory.GetCurrentDirectory(), "Key", "mumbi-app-84d15-firebase-adminsdk-jjgue-ec3c0f147b.json");
            FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromFile(pathToKey)
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                var firebaseProject = configuration.GetSection("AppSettings:FirebaseProject").Value;
                var tokenValue = configuration["JWTSettings:Key"];
                o.SaveToken = true;
                o.RequireHttpsMetadata = false;
                o.Authority = "https://securetoken.google.com/" + firebaseProject;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = firebaseProject,
                    ValidIssuer = "https://securetoken.google.com/" + firebaseProject,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenValue))
                };
            });

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}
