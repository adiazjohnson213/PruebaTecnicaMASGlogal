using HandsOnTest.Business.Services;
using HandsOnTest.Repository.Extention;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HandsOnTest.Business.Extention
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServicesDependencies(
           this IServiceCollection services,
           IConfiguration configuration)
        {
            services.AddSingleton<IEmployeeBusiness, EmployeeBusiness>();
            services.AddRespositoryDependencies(configuration);

            return services;
        }
    }
}
