using System;
using MikeAssets.ModularServiceLocator.Interfaces;

namespace MikeAssets.ModularServiceLocator.Bindings
{
    public interface IBinding
    {
        Type Service { get; }
        
        IBindingConfiguration Configuration { get; }
    }
}