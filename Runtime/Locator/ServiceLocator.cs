using System.Collections.Generic;

namespace MikeAssets.ModularServiceLocator.Runtime
{
    public class ServiceLocator : BindingRoot, IServiceLocator
    {
        public IReadOnlyBindingRoot Root => this;

        public bool IsModuleRegistered(string name)
        {
            return IsModuleExists(name);
        }

        public void RegisterModule(LocatorModule module)
        {
            base.RegisterModule(module);
        }

        public void UnregisterModule(string name)
        {
            base.UnregisterModule(name);
        }

        public IBindingProvider ResolveProvider<T>()
        {
            var service = typeof(T);

            return m_bindings.TryGetValue(service, out var binding) ? binding.Configuration.Provider : null;
        }

        public IList<IBinding> Bindings => RootBindings;
    }
}