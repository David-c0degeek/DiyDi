using System;

namespace DiyDiContainer
{
    public interface IRandomGuidProvider
    {
        Guid RandomGuid { get; }
    }
}