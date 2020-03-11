using Microsoft.Practices.Unity.TestSupport;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Configuration
{
    [TestClass]
    public class ContainerExtensionsInContainer : UnityConfigurationFixture
    {
        [ClassInitialize]
        public static void SetupTests(TestContext context) => InitializeClass(context, "ContainerExtensions.config");

        [TestInitialize]
        public void SetupTest() => LoadContainer();

        [TestMethod]
        public void ContainerHasExtensionAdded()
        {
            Assert.IsNotNull(Container.Configure<MockContainerExtension>());
        }
    }
}
