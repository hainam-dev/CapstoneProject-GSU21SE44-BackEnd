using Microsoft.Extensions.DependencyInjection;
using Mumbi.Application.Interfaces;
using Mumbi.Application.Services;

namespace Mumbi.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IAccountService, AccountService>();
        }
    }
}
