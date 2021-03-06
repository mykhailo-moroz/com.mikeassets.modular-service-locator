using System;

namespace SolarSystem.Interfaces
{
    public interface IResolveRequest
    {
        IReadOnlyBindingRoot Root { get; }
        
        Type Service { get; }
    }
}