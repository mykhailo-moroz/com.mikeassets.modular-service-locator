using ikeAssets.ModularServiceLocator.Enums;
using MikeAssets.ModularServiceLocator.Bindings.Providers;
using MikeAssets.ModularServiceLocator.Interfaces;

namespace MikeAssets.ModularServiceLocator.Bindings
{
    public class BindingBuilder<T> : BindingBuilderBase, IBindingBuilder<T>
    {
        public BindingBuilder(IBindingConfiguration bindingConfiguration) : base(bindingConfiguration)
        {
        }

        public void ToTransient<TImplementation>() where TImplementation : T
        {
            m_configuration.BindingType = BindingType.Transient;

            var service = typeof(T);
            var implementationType = typeof(TImplementation);
            var provider = new TransientBindingProvider(implementationType);
            provider.Contracts.Add(service);

            m_configuration.Provider = provider;
        }

        public void ToConstant(object constant)
        {
            m_configuration.BindingType = BindingType.Constant;

            var service = typeof(T);
            var provider = new ConstantBindingProvider(constant);
            
            provider.Contracts.Add(service);

            m_configuration.Provider = provider;
        }
    }
    
    public class BindingBuilder<T1, T2> : BindingBuilderBase, IBindingBuilder<T1, T2>
    {
        public BindingBuilder(IBindingConfiguration bindingConfiguration) : base(bindingConfiguration)
        {
        }

        public void ToTransient<TImplementation>() where TImplementation : T1, T2
        {
            m_configuration.BindingType = BindingType.Transient;

            var service1 = typeof(T1);
            var service2 = typeof(T2);

            var implementationType = typeof(TImplementation);
            
            var provider = new TransientBindingProvider(implementationType);
            provider.Contracts.Add(service1);
            provider.Contracts.Add(service2);

            m_configuration.Provider = provider;
        }

        public void ToConstant(object constant)
        {
            m_configuration.BindingType = BindingType.Constant;
            
            var service1 = typeof(T1);
            var service2 = typeof(T2);
            
            var provider = new ConstantBindingProvider(constant);
            provider.Contracts.Add(service1);
            provider.Contracts.Add(service2);

            m_configuration.Provider = provider;
        }
    }
}