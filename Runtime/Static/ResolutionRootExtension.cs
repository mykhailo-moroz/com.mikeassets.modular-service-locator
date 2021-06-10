using System.Linq;

namespace MikeAssets.ModularServiceLocator.Runtime
{
    public static class ResolutionRootExtension
    {
        public static T Get<T>(this IResolutionRoot resolutionRoot)
        {
            var service = typeof(T);
            var provider = resolutionRoot.ResolveProvider<T>();

            var request = new ResolveRequest(resolutionRoot.Root, service);
            
            return (T)provider.ResolveValue(request);
        }

        public static void ResolveSingletons(this IResolutionRoot resolutionRoot)
        {
            var bindingsToResolve =
                resolutionRoot.Bindings.Where(binding => binding.Configuration.Provider is SingletoneBindingProvider);

            var toResolve = bindingsToResolve.ToList();
            if (!toResolve.Any())
            {
                return;
            }

            foreach (var binding in toResolve)
            {
                var request = new ResolveRequest(resolutionRoot.Root, binding.Service);
                binding.Configuration.Provider.ResolveValue(request);
            }
        }
    }
}