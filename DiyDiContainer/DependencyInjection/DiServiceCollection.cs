using System;
using System.Collections.Generic;

namespace DiyDiContainer.DependencyInjection
{
    public class DiServiceCollection
    {
        private Dictionary<Type, ServiceDescriptor> ServicesDict { get; } = new();
        
        public void RegisterSingleton<TService>()
        {
            var type = typeof(TService);
            ServicesDict.TryAdd(type, new ServiceDescriptor(type, ServiceLifetime.Singleton));
        }
        
        public void RegisterSingleton<TService>(TService implementation)
        {
            ServicesDict.TryAdd(implementation.GetType(),
                new ServiceDescriptor(implementation, ServiceLifetime.Singleton));
        }
        
        public void RegisterSingleton<TService, TImplementation>() where TImplementation : TService
        {
            var typeOfService = typeof(TService);
            ServicesDict.TryAdd(typeOfService, new ServiceDescriptor(typeOfService, typeof(TImplementation), ServiceLifetime.Singleton));
        }

        public void RegisterTransient<TService>()
        {
            var type = typeof(TService);
            ServicesDict.TryAdd(type, new ServiceDescriptor(type, ServiceLifetime.Transient));
        }
        
        public void RegisterTransient<TService>(TService implementation)
        {
            ServicesDict.TryAdd(implementation.GetType(),
                new ServiceDescriptor(implementation, ServiceLifetime.Transient));
        }
        
        public void RegisterTransient<TService, TImplementation>() where TImplementation : TService
        {
            var typeOfService = typeof(TService);
            ServicesDict.TryAdd(typeOfService, new ServiceDescriptor(typeOfService, typeof(TImplementation), ServiceLifetime.Transient));
        }

        public DiContainer GenerateContainer()
        {
            return new(ServicesDict);
        }
    }
}