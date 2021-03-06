using System;
using System.Linq;
using SolarSystem.Interfaces;

namespace MikeAssets.ModularServiceLocator.Bindings.Providers
{
    public class ConstantBindingProvider : BindingProviderBase
    {
        private readonly object m_service;
        
        public ConstantBindingProvider(object service)
        {
            m_service = service;
        }
        
        public override object ResolveValue(IResolveRequest request)
        {
            return Contracts.Contains(request.Service) ? m_service : null;
        }
    }
}