using System;

namespace DiyDiContainer
{
    public class RandomGuidProvider : IRandomGuidProvider
    {
        public Guid RandomGuid { get; } = Guid.NewGuid();
    }
}