using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Onion.Instrastructure {
    public static class DependencyContainer {
        public static IServiceCollection AddInfrastructure (this IServiceCollection services, IConfiguration configuration) {

            return services;
        }
    }
}