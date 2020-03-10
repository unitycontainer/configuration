using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Configuration.Section
{
    [TestClass]
    public class LoadingEmptySection : UnityConfigurationFixture
    {
        [ClassInitialize]
        public static void SetupTests(TestContext context) 
        {
            SetupTests(context, "EmptySection");
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
            Assert.IsInstanceOfType(section, typeof(Unity.Configuration.UnityConfigurationSection));
        }
    }
}
