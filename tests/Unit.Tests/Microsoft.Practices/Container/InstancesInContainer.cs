using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace Microsoft.Practices
{
    [TestClass]
    public class InstancesInContainer : MicrosoftPracticesFixture
    {
        [ClassInitialize]
        public static void SetupTests(TestContext context) => InitializeClass(context, "RegisteringInstances.config");

        [TestInitialize]
        public void SetupTest() => LoadContainer();

        [TestMethod]
        public void DefaultStringInstanceIsRegistered()
        {
            Assert.AreEqual("AdventureWorks", Container.Resolve<string>());
        }

        [TestMethod]
        public void DefaultIntInstanceIsRegistered()
        {
            Assert.AreEqual(42, Container.Resolve<int>());
        }

        [TestMethod]
        public void NamedIntIsRegistered()
        {
            Assert.AreEqual(23, Container.Resolve<int>("forward"));
        }

        [TestMethod]
        public void InstanceUsingTypeConverterIsCreatedProperly()
        {
            Assert.AreEqual(-23, Container.Resolve<int>("negated"));
        }
    }
}
