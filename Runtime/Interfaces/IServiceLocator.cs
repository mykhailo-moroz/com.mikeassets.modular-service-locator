using MikeAssets.ModularServiceLocator.Modules;

namespace MikeAssets.ModularServiceLocator.Interfaces
{
    public interface IServiceLocator : IResolutionRoot
    {
        bool IsModuleRegistered(string name);
        void RegisterModule(LocatorModule module);
        void UnregisterModule(string name);
    }
}