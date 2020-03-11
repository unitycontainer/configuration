using Microsoft.Practices.Unity.Configuration.Tests.TestObjects;
using Microsoft.Practices.Unity.TestSupport;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Configuration
{
    [TestClass]
    public class MethodInjectionInContainer : UnityConfigurationFixture
    {
        [ClassInitialize]
        public static void SetupTests(TestContext context) => InitializeClass(context, "MethodInjection.config");

        [TestInitialize]
        public void SetupTest() => LoadContainer();

        [TestMethod]
        public void SingleInjectionMethodIsCalledWithExpectedValues()
        {
            var result = Container.Resolve<ObjectWithInjectionMethod>("singleMethod");

            Assert.AreEqual("northwind", result.ConnectionString);
            Assert.IsInstanceOfType(result.Logger, typeof(MockLogger));
        }

        [TestMethod]
        public void MultipleInjectionMethodsCalledWithExpectedValues()
        {
            var result = Container.Resolve<ObjectWithInjectionMethod>("twoMethods");

            Assert.AreEqual("northwind", result.ConnectionString);
            Assert.IsInstanceOfType(result.Logger, typeof(MockLogger));
            Assert.IsNotNull(result.MoreData);
        }

        [TestMethod]
        public void CorrectFirstOverloadIsCalled()
        {
            var result = Container.Resolve<ObjectWithOverloads>("callFirstOverload");

            Assert.AreEqual(1, result.FirstOverloadCalls);
            Assert.AreEqual(0, result.SecondOverloadCalls);
        }

        [TestMethod]
        public void CorrectSecondOverloadIsCalled()
        {
            var result = Container.Resolve<ObjectWithOverloads>("callSecondOverload");

            Assert.AreEqual(0, result.FirstOverloadCalls);
            Assert.AreEqual(1, result.SecondOverloadCalls);
        }

        [TestMethod]
        public void BothOverloadsAreCalled()
        {
            var result = Container.Resolve<ObjectWithOverloads>("callBothOverloads");

            Assert.AreEqual(1, result.FirstOverloadCalls);
            Assert.AreEqual(1, result.SecondOverloadCalls);
        }

        [TestMethod]
        public void FirstOverloadIsNotCalledTwice()
        {
            var result = Container.Resolve<ObjectWithOverloads>("callFirstOverloadTwice");

            Assert.AreEqual(1, result.FirstOverloadCalls);
            Assert.AreEqual(0, result.SecondOverloadCalls);
        }
    }
}
