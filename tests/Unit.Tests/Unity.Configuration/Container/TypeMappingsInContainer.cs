using Microsoft.Practices.Unity.TestSupport;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Unity.Lifetime;

namespace Unity.Configuration
{
    [TestClass]
    public class TypeMappingsInContainer : UnityConfigurationFixture
    {
        [ClassInitialize]
        public static void SetupTests(TestContext context) => InitializeClass(context, "BasicTypeMapping.config");

        [TestInitialize]
        public void SetupTest() => LoadContainer();

        [TestMethod]
        public void ContainerHasTwoMappingsForILogger()
        {
            Assert.AreEqual(2,
               Container.Registrations.Where(r => r.RegisteredType == typeof(ILogger)).Count());
        }

        [TestMethod]
        public void DefaultILoggerIsMappedToMockLogger()
        {
            Assert.AreEqual(typeof(MockLogger),
               Container.Registrations
                    .Where(r => r.RegisteredType == typeof(ILogger) && r.Name == null)
                    .Select(r => r.MappedToType)
                    .First());
        }

        [TestMethod]
        public void SpecialILoggerIsMappedToSpecialLogger()
        {
            Assert.AreEqual(typeof(SpecialLogger),
               Container.Registrations
                    .Where(r => r.RegisteredType == typeof(ILogger) && r.Name == "special")
                    .Select(r => r.MappedToType)
                    .First());
        }

        [TestMethod]
        public void AllRegistrationsHaveTransientLifetime()
        {
            Assert.IsTrue(Container.Registrations
                .Where(r => r.RegisteredType == typeof(ILogger))
                .All(r => r.LifetimeManager?.GetType() == typeof(TransientLifetimeManager)));
        }
    }
}
