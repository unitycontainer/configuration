using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity.Configuration;

namespace Microsoft.Practices
{
    [TestClass]
    public class EmptySection : MicrosoftPracticesFixture
    {
        [ClassInitialize]
        public static void SetupTests(TestContext context) => InitializeClass(context, "EmptySection.config");

        [TestMethod]
        public void SectionIsMissing()
        {
            Assert.IsNull(GetSection("bogus"));
        }

        [TestMethod]
        public void SectionIsPresent()
        {
            var section = Section;

            Assert.IsNotNull(section);
            Assert.IsInstanceOfType(section, typeof(UnityConfigurationSection));
        }
    }
}
