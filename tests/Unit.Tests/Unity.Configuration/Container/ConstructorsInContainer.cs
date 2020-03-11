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

        // Disable obsolete warning for this one test
#pragma warning disable 618
        [TestMethod]
        public void OldConfigureAPIStillWorks()
        {
            CreateContainer();
            Section.Containers["defaultConstructor"].Configure(Container);
            var result = Container.Resolve<MockDatabase>();
            Assert.IsTrue(result.DefaultConstructorCalled);
        }
#pragma warning restore 618
    }
}
