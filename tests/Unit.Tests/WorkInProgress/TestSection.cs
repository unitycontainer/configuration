using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity.Configuration;

namespace WorkInProgress.Tests
{
    [TestClass]
    public class TestSection : UnityConfigurationFixture
    {
        [ClassInitialize]
        public static void SetupTests(TestContext context) => InitializeClass(context);

        [TestMethod]
        public void TestDefaultSection()
        {
            Assert.IsNotNull(Section);
            Assert.IsInstanceOfType(Section, typeof(UnityConfigurationSection));
        }


        [TestMethod]
        public void TestLoadedSection()
        {
            UnityConfigurationSection Loaded = GetSection("loaded");

            Assert.IsNotNull(Loaded);
            Assert.IsInstanceOfType(Loaded, typeof(UnityConfigurationSection));
            Assert.AreEqual(2, Loaded.Containers.Default.Registrations.Count);
        }
    }
}
