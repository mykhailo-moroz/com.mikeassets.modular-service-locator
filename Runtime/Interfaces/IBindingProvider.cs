using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace MikeAssets.ModularServiceLocator.Runtime
{
    public interface IBindingProvider
    {
        ConcurrentBag<Type> Contracts { get; }

        Dictionary<string, Type> GetConstructorParams();
        
        object ResolveValue(IResolveRequest request);
    }
}