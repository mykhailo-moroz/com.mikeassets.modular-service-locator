using ikeAssets.ModularServiceLocator.Enums;
using MikeAssets.ModularServiceLocator.Interfaces;

namespace MikeAssets.ModularServiceLocator.Bindings
{
    public class BindingConfiguration : IBindingConfiguration
    {
        public BindingType BindingType { get; set; }

        public IBindingProvider Provider { get; set; }
    }
}