using System.Collections.Generic;
using MikeAssets.ModularServiceLocator.Bindings;

namespace SolarSystem.Interfaces
{
    public interface IReadOnlyBindingRoot
    {
        List<IBinding> Bindings { get; }
    }
}