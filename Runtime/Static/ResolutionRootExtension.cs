using MikeAssets.ModularServiceLocator.Bindings;
using MikeAssets.ModularServiceLocator.Interfaces;

namespace MikeAssets.ModularServiceLocator.Static
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
    }
}