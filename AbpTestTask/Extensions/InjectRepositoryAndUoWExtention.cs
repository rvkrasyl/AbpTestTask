using AbpDal.Data;
using AbpDal.Data.Interfaces;
using AbpDal.Repositories;
using AbpDal.Repositories.Interfaces;

namespace AbpWebApi.Extensions
{
    public static class InjectRepositoryAndUoWExtention
    {
        public static IServiceCollection AddRepositoriesAndUoW(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
