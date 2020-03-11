using Microsoft.Practices.Unity.TestSupport;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Unity.Configuration
{
    [TestClass]
    public class Aliases : UnityConfigurationFixture
    {
        [ClassInitialize]
        public static void SetupTests(TestContext context) => InitializeClass(context, "TwoContainersAndAliases.config");

        [TestMethod]
        public void AliasesAreAvailableInTheSection()
        {
            Assert.IsNotNull(Section.TypeAliases);
        }

        [TestMethod]
        public void ExpectedNumberOfAliasesArePresent()
        {
            Assert.AreEqual(2, Section.TypeAliases.Count);
        }

        [TestMethod]
        public void IntIsMappedToSystemInt32()
        {
            Assert.AreEqual("System.Int32, mscorlib", Section.TypeAliases["int"]);
        }

        [TestMethod]
        public void StringIsMappedToSystemString()
        {
            Assert.AreEqual("System.String, mscorlib", Section.TypeAliases["string"]);
        }

        [TestMethod]
        public void EnumerationReturnsAliasesInOrderAsGivenInFile()
        {
            CollectionAssertExtensions.AreEqual(new[] { "int", "string" },
                Section.TypeAliases.Select(alias => alias.Alias).ToList());
        }

        [TestMethod]
        public void ContainersInTheFileAreAlsoLoaded()
        {
            Assert.AreEqual(2, Section.Containers.Count);
        }
    }
}
