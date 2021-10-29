using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace NamesOutOfAHat.Client.Utility
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServicesInAssembly(this IServiceCollection serviceCollection, Type type)
        {
            var services = Assembly.GetAssembly(type)
                .GetTypes()
                .Where(x => !x.IsAbstract)
                .Where(x => x.IsPublic)
                ;

            foreach(var service in services)
            {
                var interfaces = service.GetInterfaces().ToList();
                
                foreach(var i in interfaces)
                    serviceCollection.AddSingleton(i, service);

                serviceCollection.AddSingleton(service);
            }

            return serviceCollection;
        }
    }
}
