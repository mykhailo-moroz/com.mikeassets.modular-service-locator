using System;

namespace MikeAssets.ModularServiceLocator.Runtime
{
    public interface IBinding
    {
        Type Service { get; }
        
        IBindingConfiguration Configuration { get; }
    }
}