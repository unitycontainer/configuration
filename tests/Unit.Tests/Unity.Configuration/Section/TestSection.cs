using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Configuration
{
    [TestClass]
    public class TestSection : UnityConfigurationFixture
    {
        [ClassInitialize]
        public static void SetupTests(TestContext context) => InitializeClass(context, "Test-Section");


        [TestMethod]
        public void TestDefaultSection()
        {
            Assert.IsNotNull(Section);
            Assert.IsInstanceOfType(Section, typeof(UnityConfigurationSection));
        }
    }
}
