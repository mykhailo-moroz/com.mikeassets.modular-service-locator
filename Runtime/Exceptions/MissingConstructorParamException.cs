using System;

namespace MikeAssets.ModularServiceLocator
{
    public class MissingConstructorParamException : Exception
    {
        public Type Service { get; }
        
        public MissingConstructorParamException(Type service, string parameterName) :
            base($"Cannot construct type {service}, constructor parameter '{parameterName}' is not initialized")
        {
        }
    }
}