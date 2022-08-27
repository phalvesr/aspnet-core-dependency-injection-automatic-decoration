using DecoratedUnitOfWork.Services.ItemOneServices;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace DecoratedUnitOfWork.Decoration
{
    public static class DecoratorExtensions
    {
        public static IServiceCollection AddScopedWithDecoration<TService, TDecorator, TDecorated>(this IServiceCollection services) 
            where TDecorated : class, TService
            where TDecorator : class, TService
            where TService : class
        {
            services.AddScoped<TDecorated>();
            using var sp = services.BuildServiceProvider();

            var parameters = typeof(TDecorator).GetConstructors()[0].GetParameters();

            var constructorArgs = parameters.Select(x => sp.GetRequiredService(x.ParameterType)).ToArray();

            TDecorator a = (TDecorator)Activator.CreateInstance(typeof(TDecorator), constructorArgs)!;

            services.AddScoped<TService>(_ => a);

            return services;
        }
    }
}
