using System.Collections.Generic;

namespace MikeAssets.ModularServiceLocator.Runtime
{
    public interface IResolutionRoot
    {
        IReadOnlyBindingRoot Root { get; }
        
        IBindingProvider ResolveProvider<T>();
        
        IList<IBinding> Bindings { get; }
    }
}