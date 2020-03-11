using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Microsoft.Practices
{
    /// <summary>
    /// Summary description for When_LoadingConfigWithLifetimes
    /// </summary>
    [TestClass]
    public class Lifetimes : MicrosoftPracticesFixture
    {
        [ClassInitialize]
        public static void SetupTests(TestContext context) => InitializeClass(context, "Lifetimes.config");

        [TestMethod]
        public void ILoggerHasSingletonLifetime()
        {
            var registration = Section.Containers.Default.Registrations.Where(
                r => r.TypeName == "ILogger" && r.Name == string.Empty).First();

            Assert.AreEqual("singleton", registration.Lifetime.TypeName);
        }

        [TestMethod]
        public void TypeConverterInformationIsProperlyDeserialized()
        {
            var lifetime = Section.Containers.Default.Registrations
                .Where(r => r.TypeName == "ILogger" && r.Name == "reverseSession")
                .First()
                .Lifetime;

            Assert.AreEqual("session", lifetime.TypeName);
            Assert.AreEqual("backwards", lifetime.Value);
            Assert.AreEqual("reversed", lifetime.TypeConverterTypeName);
        }
    }
}
