using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Configuration
{
    [TestClass]
    public class ContainerExtensions : UnityConfigurationFixture
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
        public void Then_ContainerElementContainsOneExtension()
        {
            Assert.AreEqual(1, defaultContainer.Extensions.Count);
        }

        [TestMethod]
        public void Then_ExtensionElementHasExpectedType()
        {
            Assert.AreEqual("MockContainerExtension", defaultContainer.Extensions[0].TypeName);
        }

        [TestMethod]
        public void Then_NewSchemaContainerContainsOneExtension()
        {
            Assert.AreEqual(1, newSchemaContainer.Extensions.Count);
        }

        [TestMethod]
        public void Then_NewSchemaContainerExtensionElementHasExpectedType()
        {
            Assert.AreEqual("MockContainerExtension", newSchemaContainer.Extensions[0].TypeName);
        }
    }
}
