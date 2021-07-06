using System;
using System.Collections.Generic;
using System.Linq;

namespace MikeAssets.ModularServiceLocator.Runtime
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

        public override Dictionary<string, Type> GetConstructorParams()
        {
            return null;
        }
    }
}