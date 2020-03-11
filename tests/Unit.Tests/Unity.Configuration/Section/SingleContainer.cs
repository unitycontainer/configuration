using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Configuration
{
    [TestClass]
    public class SingleContainer : UnityConfigurationFixture
    {
        [ClassInitialize]
        public static void SetupTests(TestContext context) => InitializeClass(context, "SingleSectionSingleContainer.config");

        [TestMethod]
        public void SectionIsNotNull()
        {
            Assert.IsNotNull(Section);
        }

        [TestMethod]
        public void ContainersPropertyIsSet()
        {
            Assert.IsNotNull(Section.Containers);
        }

        [TestMethod]
        public void ThereIsOneContainerInSection()
        {
            Assert.AreEqual(1, Section.Containers.Count);
        }
    }
}
