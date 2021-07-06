using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MikeAssets.ModularServiceLocator.Runtime
{
    public class TransientBindingProvider : BindingProviderBase
    {
        public Type Implementation { get; }

        public TransientBindingProvider(Type implementation)
        {
            Implementation = implementation;
        }
        
        public override object ResolveValue(IResolveRequest request)
        {
            if (!Contracts.Contains(request.Service))
            {
                return null;
            }

            if (request.IsCyclic(request.Service))
            {
                throw new CyclicDependencyException(request.Service);
            }
            
            var constructors = Implementation.GetConstructors(BindingFlags.Instance | BindingFlags.Public);
            
            var constructor = constructors.OrderBy(ct => ct.GetParameters().Length).First();
            var constructorParams = constructor.GetParameters().ToDictionary(pr => pr.Name, pr => pr.ParameterType);
            var bindings = request.Root.RootBindings;

            if (!constructorParams.Any() && request.ChildRequests == null)
            {
                return constructor.Invoke(null);
            }

            var parameters = new List<object>();

            if (request.ChildRequests.Any())
            {
                parameters.AddRange(from req in request.ChildRequests let binding = bindings.First(bi => bi.Service == req.Service) let resolutionProvider = binding.Configuration.Provider select resolutionProvider.ResolveValue(req));
            }

            var instance = constructor.Invoke(parameters.ToArray());
            
            return instance;
        }

        public override Dictionary<string, Type> GetConstructorParams()
        {
            var constructors = Implementation.GetConstructors(BindingFlags.Instance | BindingFlags.Public);
            
            var constructor = constructors.OrderBy(ct => ct.GetParameters().Length).First();
            return constructor.GetParameters().ToDictionary(pr => pr.Name, pr => pr.ParameterType);
        }
    }
}