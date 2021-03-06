using MikeAssets.ModularServiceLocator.Bindings;

namespace MikeAssets.ModularServiceLocator.Modules
{
    public abstract class LocatorModule : BindingRoot
    {
        public string Name { get; }

        public LocatorModule()
        {
            Name = GetType().ToString();
        }
        
        public abstract void Load();

        public virtual void Unload()
        {
            
        }
    }
}