using System;

namespace DiyDiContainer
{
    public class SomeService1 : ISomeService
    {
        private readonly IRandomGuidProvider _randomGuidProvider;

        public SomeService1(IRandomGuidProvider randomGuidProvider)
        {
            _randomGuidProvider = randomGuidProvider;
        }
        
        public void PrintSomething()
        {
            Console.WriteLine(_randomGuidProvider.RandomGuid);
        }
    }
}