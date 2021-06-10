using System;

namespace MikeAssets.ModularServiceLocator.Runtime
{
    public interface IResolveRequest
    {
        IReadOnlyBindingRoot Root { get; }
        
        Type Service { get; }
    }
}