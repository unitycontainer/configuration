using Microsoft.Practices.Unity.TestSupport;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Unity.Configuration
{
    [TestClass]
    public class ConstructorsInContainer : UnityConfigurationFixture
    {
        [ClassInitialize]
        public static void SetupTests(TestContext context) => InitializeClass(context, "VariousConstructors.config");

        [TestMethod]
        public void CanResolveMockDatabaseAndItCallsDefaultConstructor()
        {
            LoadContainer("defaultConstructor");
            
            var result = Container.Resolve<MockDatabase>();
            Assert.IsTrue(result.DefaultConstructorCalled);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ConstructorsThatDoNotMatchThrowAnException()
        {
            LoadContainer("invalidConstructor");
        }
    }
}
