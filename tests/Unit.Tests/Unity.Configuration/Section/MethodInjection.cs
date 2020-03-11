using Microsoft.Practices.Unity.TestSupport;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Unity.Configuration
{
    [TestClass]
    public class MethodInjection : UnityConfigurationFixture
    {
        [ClassInitialize]
        public static void SetupTests(TestContext context) => InitializeClass(context, "MethodInjection.config");

        [TestMethod]
        public void FirstRegistrationHasOneMethodInjection()
        {
            var registration = (from reg in Section.Containers.Default.Registrations
                                where reg.TypeName == "ObjectWithInjectionMethod" && reg.Name == "singleMethod"
                                select reg).First();

            Assert.AreEqual(1, registration.InjectionMembers.Count);
            var methodRegistration = (MethodElement)registration.InjectionMembers[0];

            Assert.AreEqual("Initialize", methodRegistration.Name);
            CollectionAssertExtensions.AreEqual(new string[] { "connectionString", "logger" },
                methodRegistration.Parameters.Select(p => p.Name).ToList());
        }
    }
}
