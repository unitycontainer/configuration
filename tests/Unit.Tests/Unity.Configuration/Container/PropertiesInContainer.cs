using Microsoft.Practices.Unity.TestSupport;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Configuration
{
    [TestClass]
    public class PropertiesInContainer : UnityConfigurationFixture
    {
        [ClassInitialize]
        public static void SetupTests(TestContext context) => InitializeClass(context, "Properties.config");

        [TestInitialize]
        public void SetupTest() => LoadContainer();

        [TestMethod]
        public void InjectedPropertyIsResolvedAccordingToConfiguration()
        {
            var expected = Container.Resolve<object>("special");
            var result = Container.Resolve<ObjectWithTwoProperties>("singleProperty");

            Assert.AreSame(expected, result.Obj1);
        }

        [TestMethod]
        public void InjectedPropertyIsResolvedAccordingToConfigurationUsingAttributes()
        {
            var expected = Container.Resolve<object>("special");
            var result = Container.Resolve<ObjectWithTwoProperties>("twoProperties");

            Assert.AreSame(expected, result.Obj1);
        }

        [TestMethod]
        public void InjectedPropertyIsProperType()
        {
            var result = Container.Resolve<ObjectWithTwoProperties>("injectingDifferentType");

            Assert.IsInstanceOfType(result.Obj1, typeof(SpecialLogger));
        }

        [TestMethod]
        public void MultiplePropertiesGetInjected()
        {
            var expected = Container.Resolve<object>("special");
            var result = Container.Resolve<ObjectWithTwoProperties>("injectingDifferentType");

            Assert.IsInstanceOfType(result.Obj1, typeof(SpecialLogger));
            Assert.AreSame(expected, result.Obj2);
        }
    }
}
