using SolarSystem.Interfaces;

namespace MikeAssets.ModularServiceLocator.Interfaces
{
    public interface IResolutionRoot
    {
        IReadOnlyBindingRoot Root { get; }
        
        IBindingProvider ResolveProvider<T>();
    }
}