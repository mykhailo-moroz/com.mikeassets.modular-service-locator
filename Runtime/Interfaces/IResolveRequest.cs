using System;
using System.Collections.Generic;

namespace MikeAssets.ModularServiceLocator.Runtime
{
    public interface IResolveRequest
    {
        IReadOnlyBindingRoot Root { get; }
        
        IResolveRequest ParentRequest { get; }
        
        IList<IResolveRequest> ChildRequests { get; set; }
        
        Type Service { get; }

        bool IsCyclic(Type serviceToCheck);
    }
}