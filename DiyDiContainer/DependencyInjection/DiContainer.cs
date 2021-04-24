using System;
using System.Collections.Generic;
using System.Linq;

namespace DiyDiContainer.DependencyInjection
{
    public class DiContainer
    {
        private Dictionary<Type, ServiceDescriptor> ServicesDict { get; }
        
        public DiContainer(Dictionary<Type, ServiceDescriptor> servicesDict)
        {
            ServicesDict = servicesDict;
        }

        public object GetService(Type serviceType)
        {
            if (!ServicesDict.TryGetValue(serviceType, out var descriptor))
                throw new Exception($"Service of type {serviceType.Namespace} is not registered");

            if(descriptor.Implementation != null)
                return descriptor.Implementation;

            var actualType = descriptor.ImplementationType ?? descriptor.ServiceType;

            if (actualType.IsAbstract || actualType.IsInterface)
                throw new Exception("Cannot instantiate abstract classes or interfaces");

            var constructorInfo = actualType
                .GetConstructors()
                .First();

            var parameters = constructorInfo
                .GetParameters()
                .Select(x => GetService(x.ParameterType))
                .ToArray();

            var implementation = Activator
                .CreateInstance(actualType, parameters);
            
            if (descriptor.LifeTime == ServiceLifetime.Singleton)
                descriptor.Implementation = implementation;
            
            return implementation;
        }
        
        public T GetService<T>()
        {
            return (T) GetService(typeof(T));
        }
    }
}