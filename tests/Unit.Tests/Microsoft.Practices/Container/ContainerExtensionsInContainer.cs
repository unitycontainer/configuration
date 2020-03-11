using Microsoft.Practices.Unity.TestSupport;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace Microsoft.Practices
{
    [TestClass]
    public class ContainerExtensionsInContainer : MicrosoftPracticesFixture
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
