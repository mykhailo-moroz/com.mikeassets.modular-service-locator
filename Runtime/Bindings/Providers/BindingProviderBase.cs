using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace MikeAssets.ModularServiceLocator.Runtime
{
    public abstract class BindingProviderBase : IBindingProvider
    {
        public ConcurrentBag<Type> Contracts { get; }

        public abstract object ResolveValue(IResolveRequest request);

        public abstract Dictionary<string, Type> GetConstructorParams();

        protected BindingProviderBase()
        {
            Contracts = new ConcurrentBag<Type>();
        }
    }
}