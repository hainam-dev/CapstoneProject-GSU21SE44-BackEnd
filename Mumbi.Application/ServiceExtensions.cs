using Microsoft.Extensions.DependencyInjection;
using Mumbi.Application.Interfaces;
using Mumbi.Application.Services;
using System.Reflection;

namespace Mumbi.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IChildrenService, ChildrenService>();
            services.AddTransient<IMomService, MomService>();
            services.AddTransient<IDadService, DadService>();
            services.AddTransient<IStaffService, StaffService>();
            services.AddTransient<IDiaryService, DiaryService>();
            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<INewsTypeService, NewsTypeService>();
            services.AddTransient<INewsMomService, NewsMomService>();
            services.AddTransient<IGuidebookService, GuidebookService>();
            services.AddTransient<IGuidebookTypeService, GuidebookTypeService>();
            services.AddTransient<IGuidebookMomService, GuidebookMomService>();
        }
    }
}
