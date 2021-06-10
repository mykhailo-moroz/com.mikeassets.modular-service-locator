namespace MikeAssets.ModularServiceLocator.Runtime
{
    public interface IBindingBuilder<T>
    {
        void ToTransient<TImplementation>() where TImplementation : T;
        void ToConstant(object constant);
        void ToSingletone<TImplementation>() where TImplementation : T;
    }
    
    public interface IBindingBuilder<T1, T2>
    {
        void ToTransient<TImplementation>() where TImplementation : T1, T2;
        void ToConstant(object constant);
        void ToSingletone<TImplementation>() where TImplementation : T1, T2;
    }
}