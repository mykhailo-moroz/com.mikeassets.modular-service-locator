namespace MikeAssets.ModularServiceLocator.Interfaces
{
    public interface IBindingBuilder<T>
    {
        void ToTransient<TImplementation>() where TImplementation : T;
        void ToConstant(object constant);
    }
    
    public interface IBindingBuilder<T1, T2>
    {
        void ToTransient<TImplementation>() where TImplementation : T1, T2;
        void ToConstant(object constant);
    }
}