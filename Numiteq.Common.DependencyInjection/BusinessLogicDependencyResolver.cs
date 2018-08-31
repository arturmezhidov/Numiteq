using Microsoft.Extensions.DependencyInjection;
using Numiteq.BusinessLogic.BusinessComponents;
using Numiteq.BusinessLogic.BusinessContracts;

namespace Numiteq.Common.DependencyInjection
{
    public static class BusinessLogicDependencyResolver
    {
        public static IServiceCollection AddBusinessComponents(this IServiceCollection services)
        {
            services.AddScoped<IDatabaseService, DatabaseService>();

            return services;
        }
    }
}
