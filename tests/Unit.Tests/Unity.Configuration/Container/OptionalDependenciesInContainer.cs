using Microsoft.Practices.Unity.TestSupport;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Configuration
{
    [TestClass]
    public class OptionalDependenciesInContainer : UnityConfigurationFixture
    {
        [ClassInitialize]
        public static void SetupTests(TestContext context) => InitializeClass(context, "OptionalDependency.config");

        [TestInitialize]
        public void SetupTest() => LoadContainer();

        [TestMethod]
        public void RegisteredOptionalDependencyIsInjected()
        {
            var result = Container.Resolve<ObjectUsingLogger>("dependencyRegistered");
            Assert.IsNotNull(result.Logger);
        }

        [TestMethod]
        public void UnregisteredOptionalDependencyIsNotInjected()
        {
            var result = Container.Resolve<ObjectUsingLogger>("dependencyNotRegistered");
            Assert.IsNull(result.Logger);
        }
    }
}
