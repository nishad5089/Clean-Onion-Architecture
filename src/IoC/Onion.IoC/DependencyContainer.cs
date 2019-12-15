using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Onion.Application;
using Onion.Instrastructure;
using Onion.Persistence;

namespace Onion.IoC {
    public static class DependencyContainer {
        public static IServiceCollection DependencyIjection (this IServiceCollection services, IConfiguration configuration) {

            services.AddPersistence (configuration);
            services.AddApplication ();
            services.AddInfrastructure (configuration);

            return services;
        }
    }
}