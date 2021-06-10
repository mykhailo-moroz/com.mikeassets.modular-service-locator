using System;

namespace MikeAssets.ModularServiceLocator.Runtime
{
    public class Binding : IBinding
    {
        public Type Service { get; }
        public IBindingConfiguration Configuration { get; }

        public Binding(Type service) : this(service, new BindingConfiguration())
        {
            
        }

        public Binding(Type service, IBindingConfiguration configuration)
        {
            Service = service;
            Configuration = configuration;
        }
    }
}