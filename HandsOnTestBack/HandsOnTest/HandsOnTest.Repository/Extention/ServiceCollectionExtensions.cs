using HandsOnTest.Repository.Config;
using HandsOnTest.Repository.Reposotories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HandsOnTest.Repository.Extention
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRespositoryDependencies(
           this IServiceCollection services,
           IConfiguration configuration)
        {
            services.AddSingleton<IMasGlobalEmployeeTestRepository, MasGlobalEmployeeTestRepository>();

            var MasGlobalEmployeeTestConfig = new MasGlobalEmployeeTestConfig
            {
                Url = configuration.GetValue<string>("ApiMasGlobal:Url")
            };
            services.AddSingleton(masGlobalEmployeeTestConfig => MasGlobalEmployeeTestConfig);

            return services;
        }
    }
}
