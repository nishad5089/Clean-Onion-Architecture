using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Onion.Application.Interfaces;
using Onion.Application.Repository;

namespace Onion.Application {
    public static class DependecyContainer {
        public static IServiceCollection AddApplication (this IServiceCollection services) {

            services.AddMediatR (Assembly.GetExecutingAssembly ());
            services.AddScoped (typeof (IQueryRepository<>), typeof (QueryRepository<>));
            services.AddScoped (typeof (ICommandRepository<>), typeof (CommandRepository<>));
            return services;
        }
    }
}