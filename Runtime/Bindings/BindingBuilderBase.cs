namespace MikeAssets.ModularServiceLocator.Runtime
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