using MikeAssets.ModularServiceLocator.Interfaces;

namespace MikeAssets.ModularServiceLocator.Bindings
{
    public abstract class BindingBuilderBase
    {
        protected readonly IBindingConfiguration m_configuration;
        
        protected BindingBuilderBase(IBindingConfiguration bindingConfiguration)
        {
            m_configuration = bindingConfiguration;
        }
    }
}