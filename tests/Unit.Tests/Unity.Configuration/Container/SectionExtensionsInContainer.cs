using Microsoft.Practices.Unity.Configuration.Tests.TestObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Configuration
{
    [TestClass]
    public class SectionExtensionsInContainer : UnityConfigurationFixture
    {
        [ClassInitialize]
        public static void SetupTests(TestContext context) => InitializeClass(context, "SectionExtensions.config");

        [TestInitialize]
        public void SetupTest() => LoadContainer();

        [TestMethod]
        public void ExtensionValueElementIsCalled()
        {
            var result = Container.Resolve<ObjectTakingScalars>();

            Assert.AreEqual(17, result.IntValue);
        }

        [TestMethod]
        public void PrefixedExtensionValueElementIsCalled()
        {
            var result = Container.Resolve<ObjectTakingScalars>("prefixedValue");

            Assert.AreEqual(17, result.IntValue);
        }
    }
}
