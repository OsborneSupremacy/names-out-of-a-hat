using Microsoft.Extensions.DependencyInjection;
using System;

namespace NamesOutOfAHat.Utility
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ServiceLifetimeAttribute : Attribute
    {
        public ServiceLifetimeAttribute(ServiceLifetime serviceLifetime)
        {
            ServiceLifetime = serviceLifetime;
        }

        public ServiceLifetime ServiceLifetime { get; }
    }
}
