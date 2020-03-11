using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices
{
    [TestClass]
    public class SingleContainer : MicrosoftPracticesFixture
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
