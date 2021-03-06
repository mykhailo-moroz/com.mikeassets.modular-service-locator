using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using SolarSystem.Interfaces;

namespace MikeAssets.ModularServiceLocator.Interfaces
{
    public interface IBindingProvider
    {
        ConcurrentBag<Type> Contracts { get; }

        object ResolveValue(IResolveRequest request);
    }
}