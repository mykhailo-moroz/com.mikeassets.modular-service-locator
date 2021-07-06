using System;
using System.Collections.Generic;
using System.Linq;

namespace MikeAssets.ModularServiceLocator.Runtime
{
    public class ResolveRequest : IResolveRequest
    {
        public IReadOnlyBindingRoot Root { get; }
        
        public IResolveRequest ParentRequest { get; }

        public IList<IResolveRequest> ChildRequests { get; set; }
        public Type Service { get; }
        public bool IsCyclic(Type serviceToCheck)
        {
            if (ChildRequests == null)
            {
                return false;
            }

            return ChildRequests.Any(req => req.Service == serviceToCheck || req.IsCyclic(serviceToCheck));
        }

        public ResolveRequest(IReadOnlyBindingRoot root, Type service) : this(root, service, null)
        {
        }

        private ResolveRequest(IReadOnlyBindingRoot root, Type service, IResolveRequest parentRequest)
        {
            Root = root;
            Service = service;
            ParentRequest = parentRequest;

            if (parentRequest == null || parentRequest.Service != service)
            {
                BuildChildRequestsGraph();   
            }

            if (parentRequest != null && parentRequest.Service == service)
            {
                ChildRequests = new List<IResolveRequest> {parentRequest};
            }
        }

        private void BuildChildRequestsGraph()
        {
            ChildRequests = new List<IResolveRequest>();
            
            var bindings = Root.RootBindings;
            var binding = bindings.First(bi => bi.Service == Service);
            var resolutionProvider = binding.Configuration.Provider;

            var constructorParams = resolutionProvider.GetConstructorParams();

            if (constructorParams == null)
            {
                return;
            }

            try
            {
                foreach (var param in constructorParams)
                {
                    var resolveRequest = new ResolveRequest(Root, param.Value, ParentRequest ?? this);
                    ChildRequests.Add(resolveRequest);
                }
            }
            catch (StackOverflowException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}