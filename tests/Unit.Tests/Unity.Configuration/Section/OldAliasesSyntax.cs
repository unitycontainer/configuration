using Microsoft.Practices.Unity.TestSupport;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Unity.Configuration
{
    /// <summary>
    /// Summary description for When_LoadingConfigUsingOldTypeAliasElements
    /// </summary>
    [TestClass]
    public class OldTypeAliasElements : UnityConfigurationFixture
    {
        [ClassInitialize]
        public static void SetupTests(TestContext context) => InitializeClass(context, "OldAliasesSyntax.config");

        [TestMethod]
        public void ExpectedNumberOfAliasesArePresent()
        {
            Assert.AreEqual(8, Section.TypeAliases.Count);
        }

        [TestMethod]
        public void AliasesAreAvailableInExpectedOrder()
        {
            CollectionAssertExtensions.AreEqual(
                new[] { "string", "int", "ILogger", "MockLogger", "SpecialLogger", "DependentConstructor", "TwoConstructorArgs", "MockDatabase" },
                Section.TypeAliases.Select(a => a.Alias).ToList());
        }
    }
}
