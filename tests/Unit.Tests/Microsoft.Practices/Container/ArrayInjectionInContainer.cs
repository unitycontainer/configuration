using Microsoft.Practices.Unity.Configuration.Tests.TestObjects;
using Microsoft.Practices.Unity.TestSupport;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Unity;

namespace Microsoft.Practices
{
    [TestClass]
    public class ArrayInjectionInContainer : MicrosoftPracticesFixture
    {
        [ClassInitialize]
        public static void SetupTests(TestContext context) => InitializeClass(context, "ArrayInjection.config");

        [TestInitialize]
        public void SetupTest() => LoadContainer();

        [TestMethod]
        public void DefaultResolutionReturnsAllRegisteredLoggers()
        {
            var result = Container.Resolve<ArrayDependencyObject>("defaultInjection");

            result.Loggers.Select(l => l.GetType()).AssertContainsInAnyOrder(
                typeof(SpecialLogger), typeof(MockLogger), typeof(MockLogger));
        }

        [TestMethod]
        public void SpecificElementsAreInjected()
        {
            var result = Container.Resolve<ArrayDependencyObject>("specificElements");

            result.Loggers.Select(l => l.GetType()).AssertContainsInAnyOrder(
                typeof(SpecialLogger), typeof(MockLogger));
        }

        [TestMethod]
        public void CanMixResolutionAndValuesInAnArray()
        {
            var result = Container.Resolve<ArrayDependencyObject>("mixingResolvesAndValues");

            result.Strings.AssertContainsExactly("first", "Not the second", "third");
        }

        [TestMethod]
        public void CanConfigureZeroLengthArrayForInjection()
        {
            var result = Container.Resolve<ArrayDependencyObject>("zeroLengthArray");

            Assert.IsNotNull(result.Strings);
            Assert.AreEqual(0, result.Strings.Length);
        }

        [TestMethod]
        public void GenericArrayPropertiesAreInjected()
        {
            var result = Container.Resolve<GenericArrayPropertyDependency<string>>("defaultResolution");

            result.Stuff.AssertContainsInAnyOrder("first", "second", "third");
        }

        [TestMethod]
        public void CanConfigureZeroLengthGenericArrayToBeInjected()
        {
            var result = Container.Resolve<GenericArrayPropertyDependency<string>>("explicitZeroLengthArray");

            Assert.AreEqual(0, result.Stuff.Count());
        }
    }
}
