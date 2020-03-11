using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Configuration
{
    [TestClass]
    public class EmptySection : UnityConfigurationFixture
    {
        [ClassInitialize]
        public static void SetupTests(TestContext context) => InitializeClass(context, "EmptySection");


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
