using MikeAssets.ModularServiceLocator.Runtime;
using NUnit.Framework;

namespace MikeAssets.ModularServiceLocator.Tests
{
    public interface ITestService { }
    public class TestService : ITestService {}
    
    public interface ITestParamsService {}

    public class TestParamsService : ITestParamsService
    {
        public TestParamsService(ITestService testService)
        {
            
        }
    }
    
    public interface ITestCircularService1 { }

    public class TestCircularService1 : ITestCircularService1
    {
        public TestCircularService1(ITestCircularService2 testCircularService2)
        {
            
        }
    }
    
    public interface ITestCircularService2 { }

    public class TestCircularService2 : ITestCircularService2
    {
        public TestCircularService2(ITestCircularService1 testCircularService1)
        {
            
        }
    }
    
    
    public class ServiceLocatorTests
    {
        [Test]
        public void ShouldCreateSimpleTransientBinding()
        {
            var locator = new ServiceLocator();
            locator.Bind<ITestService>().ToTransient<TestService>();

            var service = locator.Get<ITestService>();
            Assert.IsNotNull(service);
        }

        [Test]
        public void ShouldCreateTransientBindingsWithParams()
        {
            var locator = new ServiceLocator();
            locator.Bind<ITestService>().ToTransient<TestService>();
            locator.Bind<ITestParamsService>().ToTransient<TestParamsService>();

            var service = locator.Get<ITestParamsService>();
            Assert.IsNotNull(service);
        }

        [Test]
        public void ShouldCreateSingletoneBinding()
        {
            var locator = new ServiceLocator();
            locator.Bind<ITestService>().ToTransient<TestService>();
            locator.Bind<ITestParamsService>().ToSingletone<TestParamsService>();

            var service1 = locator.Get<ITestParamsService>();
            var service2 = locator.Get<ITestParamsService>();
            
            Assert.AreEqual(service1.GetHashCode(), service2.GetHashCode());
        }
        
        [Test]
        public void ShouldCreateSingletoneBindingOnResolveCalled()
        {
            var locator = new ServiceLocator();
            locator.Bind<ITestService>().ToTransient<TestService>();
            locator.Bind<ITestParamsService>().ToSingletone<TestParamsService>();

            locator.ResolveSingletons();
            
            var service = locator.Get<ITestParamsService>();

            Assert.NotNull(service);
        }
        
        [Test]
        public void ShouldFailWithAnExceptionIfCirlucarExceptionIsPresent()
        {
            var locator = new ServiceLocator();
            locator.Bind<ITestCircularService1>().ToTransient<TestCircularService1>();
            locator.Bind<ITestCircularService2>().ToTransient<TestCircularService2>();

            Assert.Throws<CyclicDependencyException>(() => locator.Get<ITestCircularService2>());
            Assert.Throws<CyclicDependencyException>(() => locator.Get<ITestCircularService1>());
        }
    }
}
