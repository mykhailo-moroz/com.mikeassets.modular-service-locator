using System;

namespace MikeAssets.ModularServiceLocator.Runtime
{
    public class ResolveRequest : IResolveRequest
    {
        public IReadOnlyBindingRoot Root { get; }
        public Type Service { get; }

        public ResolveRequest(IReadOnlyBindingRoot root, Type service)
        {
            Root = root;
            Service = service;
        }
    }
}