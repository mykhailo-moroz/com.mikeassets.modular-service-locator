using System;
using System.Collections.Concurrent;

namespace MikeAssets.ModularServiceLocator.Runtime
{
    public interface IBindingProvider
    {
        ConcurrentBag<Type> Contracts { get; }

        object ResolveValue(IResolveRequest request);
    }
}