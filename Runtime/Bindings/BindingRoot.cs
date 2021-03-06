using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using MikeAssets.ModularServiceLocator.Interfaces;
using MikeAssets.ModularServiceLocator.Modules;

namespace MikeAssets.ModularServiceLocator.Bindings
{
    public abstract class BindingRoot : IBindingRoot
    {
        private readonly ConcurrentDictionary<string, LocatorModule> m_modules;
        protected readonly ConcurrentDictionary<Type, IBinding> m_bindings;

        protected BindingRoot()
        {
            m_bindings = new ConcurrentDictionary<Type, IBinding>();
            m_modules = new ConcurrentDictionary<string, LocatorModule>();
        }

        public List<IBinding> Bindings => m_bindings.Values.ToList();

        public virtual void AddBinding(IBinding binding)
        {
            if (!m_bindings.ContainsKey(binding.Service))
            {
                m_bindings.TryAdd(binding.Service, binding);
            }
        }

        public virtual void RemoveBinding(IBinding binding)
        {
            m_bindings.TryRemove(binding.Service, out var _);
        }

        public IBindingBuilder<T> Bind<T>()
        {
            var binding = new Binding(typeof(T));
            
            AddBinding(binding);
            
            return new BindingBuilder<T>(binding.Configuration);
        }

        public IBindingBuilder<T1, T2> Bind<T1, T2>()
        {
            var binding = new Binding(typeof(T1));
            var secondBinding = new Binding(typeof(T2), binding.Configuration);
            
            AddBinding(binding);
            AddBinding(secondBinding);
            
            return new BindingBuilder<T1, T2>(binding.Configuration);
        }

        public void Unbind<T>()
        {
            
        }

        public void Unbind<T1, T2>()
        {
            
        }

        protected bool IsModuleExists(string name)
        {
            return m_modules.ContainsKey(name);
        }
        
        protected virtual void RegisterModule(LocatorModule module)
        {
            if (!m_modules.TryAdd(module.Name, module))
            {
                return;
            }
            
            module.Load();
            var bindings = module.Bindings;

            foreach (var binding in bindings)
            {
                m_bindings.TryAdd(binding.Service, binding);
            }
        }

        protected virtual void UnregisterModule(string name)
        {
            if (!m_modules.TryGetValue(name, out var module))
            {
                return;
            }

            var bindings = module.Bindings;

            foreach (var binding in bindings)
            {
                m_bindings.TryRemove(binding.Service, out _);
            }
            
            module.Unload();
            m_modules.TryRemove(name, out _);
        }
    }
}