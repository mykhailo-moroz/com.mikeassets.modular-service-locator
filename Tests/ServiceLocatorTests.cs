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
    }
}
