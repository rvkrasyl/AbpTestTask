using AbpBll.Services;
using AbpBll.Services.Interfaces;

namespace AbpWebApi.Extensions
{
    public static class InjectServicesExtention
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IExperimentService, ExperimentService>();
            services.AddScoped<IStatisticService, StatisticService>();

            return services;
        }
    }
}
