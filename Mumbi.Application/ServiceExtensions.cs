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
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserInfoService, UserInfoService>();
            services.AddTransient<IChildInfoService, ChildInfoService>();
            services.AddTransient<IChildHistoryService, ChildHistoryService>();
            services.AddTransient<IPregnancyHistoryService, PregnancyHistoryService>();
            services.AddTransient<IMomInfoService, MomInfoService>();
            services.AddTransient<IDadInfoService, DadInfoService>();
            services.AddTransient<IDiaryService, DiaryService>();
            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<INewsTypeService, NewsTypeService>();
            services.AddTransient<INewsMomService, NewsMomService>();
            services.AddTransient<IGuidebookService, GuidebookService>();
            services.AddTransient<IGuidebookTypeService, GuidebookTypeService>();
            services.AddTransient<IGuidebookMomService, GuidebookMomService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IToothService, ToothService>();
            services.AddTransient<IToothInfoService, ToothInfoService>();
            services.AddTransient<IInjectionScheduleService, InjectionScheduleService>();
            services.AddTransient<IInjectedPersonService, InjectedPersonService>();
            services.AddTransient<IActionChildService, ActionChildService>();
            services.AddTransient<IActionService, ActionService>();
            services.AddTransient<IActivityService, ActivityService>();
            services.AddTransient<IStandardIndexService, StandardIndexService>();
            services.AddTransient<IVaccineService, VaccineService>();
        }
    }
}
