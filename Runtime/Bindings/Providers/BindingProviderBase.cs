using System;
using System.Collections.Concurrent;

namespace MikeAssets.ModularServiceLocator.Runtime
{
    public abstract class BindingProviderBase : IBindingProvider
    {
        public ConcurrentBag<Type> Contracts { get; }

        public abstract object ResolveValue(IResolveRequest request);

        protected BindingProviderBase()
        {
            Contracts = new ConcurrentBag<Type>();
        }
    }
}