using System;
using DiyDiContainer.DependencyInjection;

namespace DiyDiContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new DiServiceCollection();

            // services.RegisterSingleton<RandomGuidGenerator>();
            // services.RegisterTransient<RandomGuidGenerator>();
            
            services.RegisterSingleton<IRandomGuidProvider, RandomGuidProvider>();
            services.RegisterTransient<ISomeService, SomeService1>();
            
            // services.RegisterSingleton(new RandomGuidGenerator());

            var container = services.GenerateContainer();

            // var service = container.GetService<RandomGuidGenerator>();
            // var service1 = container.GetService<RandomGuidGenerator>();
            
            // Console.WriteLine(service.RandomGuid);
            // Console.WriteLine(service1.RandomGuid);
            
            var service = container.GetService<ISomeService>();
            var service2 = container.GetService<ISomeService>();

            service.PrintSomething();
            service2.PrintSomething();
        }
    }
}