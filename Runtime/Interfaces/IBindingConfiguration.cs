using ikeAssets.ModularServiceLocator.Enums;

namespace MikeAssets.ModularServiceLocator.Interfaces
{
    public interface IBindingConfiguration
    {
        BindingType BindingType { get; set; }
        
        IBindingProvider Provider { get; set; }
    }
}