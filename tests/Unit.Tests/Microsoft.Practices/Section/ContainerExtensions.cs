using Microsoft.Practices.Unity.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices
{
    [TestClass]
    public class ContainerExtensions : MicrosoftPracticesFixture
    {
        private ContainerElement defaultContainer;
        private ContainerElement newSchemaContainer;

        [ClassInitialize]
        public static void SetupTests(TestContext context)
        {
            InitializeClass(context, "ContainerExtensions.config");
        }

        [TestInitialize]
        public void SetupTest()
        {
            defaultContainer = Section.Containers.Default;
            newSchemaContainer = Section.Containers["newSchema"];
        }

        [TestMethod]
        public void ContainerElementContainsOneExtension()
        {
            Assert.AreEqual(1, defaultContainer.Extensions.Count);
        }

        [TestMethod]
        public void ExtensionElementHasExpectedType()
        {
            Assert.AreEqual("MockContainerExtension", defaultContainer.Extensions[0].TypeName);
        }

        [TestMethod]
        public void NewSchemaContainerContainsOneExtension()
        {
            Assert.AreEqual(1, newSchemaContainer.Extensions.Count);
        }

        [TestMethod]
        public void NewSchemaContainerExtensionElementHasExpectedType()
        {
            Assert.AreEqual("MockContainerExtension", newSchemaContainer.Extensions[0].TypeName);
        }
    }
}
