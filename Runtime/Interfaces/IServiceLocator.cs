namespace MikeAssets.ModularServiceLocator.Runtime
{
    public interface IServiceLocator : IResolutionRoot
    {
        bool IsModuleRegistered(string name);
        void RegisterModule(LocatorModule module);
        void UnregisterModule(string name);
    }
}