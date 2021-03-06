using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MikeAssets.ModularServiceLocator.Bindings.Exceptions;
using SolarSystem.Interfaces;

namespace MikeAssets.ModularServiceLocator.Bindings.Providers
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

            var constructors = Implementation.GetConstructors(BindingFlags.Instance | BindingFlags.Public);

            var constructor = constructors.OrderBy(ct => ct.GetParameters().Length).First();
            var constructorParams = constructor.GetParameters().ToDictionary(pr => pr.Name, pr => pr.ParameterType);
            var bindings = request.Root.Bindings;

            if (!constructorParams.Any())
            {
                return constructor.Invoke(null);
            }
            
            var parameters = new Dictionary<string, object>();
            
            foreach (var param in constructorParams)
            {
                if (bindings.All(bi => bi.Service != param.Value))
                {
                    throw new MissingConstructorParamException(request.Service, param.Key);
                }

                var binding = bindings.First(bi => bi.Service == param.Value);
                var resolutionProvider = binding.Configuration.Provider;
                var resolutionRequest = new ResolveRequest(request.Root, param.Value);
                
                parameters.Add(param.Key, resolutionProvider.ResolveValue(resolutionRequest));
            }

            var instance = constructor.Invoke(parameters.Values.ToArray());
            
            return instance;
        }
    }
}