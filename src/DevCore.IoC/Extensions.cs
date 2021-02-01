using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DevCore.IoC
{
    public static class Extensions
    {
        public static void AddClassesInterfaces(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.Scan(scan => scan
                .FromAssemblies(assemblies)
                .AddClasses()
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsMatchingInterface()
                .WithScopedLifetime());
        }

        public static string GetConnectionString(this IServiceCollection services, string name)
        {
            return services
                .BuildServiceProvider()
                .GetRequiredService<IConfiguration>()
                .GetConnectionString(name);
        }
    }
}
