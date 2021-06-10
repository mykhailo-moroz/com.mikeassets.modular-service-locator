namespace MikeAssets.ModularServiceLocator.Runtime
{
    public interface IBindingRoot : IReadOnlyBindingRoot
    {
        void AddBinding(IBinding binding);
        void RemoveBinding(IBinding binding);

        IBindingBuilder<T> Bind<T>();
        IBindingBuilder<T1, T2> Bind<T1, T2>();

        void Unbind<T>();
        void Unbind<T1, T2>();
    }
}