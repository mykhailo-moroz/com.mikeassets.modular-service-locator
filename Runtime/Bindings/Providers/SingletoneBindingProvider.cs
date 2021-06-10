using System;

namespace MikeAssets.ModularServiceLocator.Runtime
{
    public class SingletoneBindingProvider : TransientBindingProvider
    {
        private object m_service;
        
        
        public SingletoneBindingProvider(Type implementation) 
            : base(implementation)
        {
        }
        
        public override object ResolveValue(IResolveRequest request)
        {
            if (m_service != null)
            {
                return m_service;
            }

            m_service = base.ResolveValue(request);
            
            return m_service;
        }
    }
}