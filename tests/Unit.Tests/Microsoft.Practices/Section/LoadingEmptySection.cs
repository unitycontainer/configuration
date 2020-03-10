using Microsoft.Practices.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Section
{
    [TestClass]
    public class LoadingEmptySection : MicrosoftPracticesFixture
    {
        [ClassInitialize]
        public static void SetupTests(TestContext context) 
        {
            SetupTests(context, "EmptySection.config");
        }

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
            Assert.IsInstanceOfType(section, typeof(Microsoft.Practices.Unity.Configuration.UnityConfigurationSection));
        }
    }
}
