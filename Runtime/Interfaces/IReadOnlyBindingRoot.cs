using System.Collections.Generic;

namespace MikeAssets.ModularServiceLocator.Runtime
{
    public interface IReadOnlyBindingRoot
    {
        List<IBinding> RootBindings { get; }
    }
}