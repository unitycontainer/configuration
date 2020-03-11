using Microsoft.Practices.Unity.Configuration.Tests.TestObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity.Injection;

namespace Unity.Configuration
{
    [TestClass]
    public class GenericsInContainer : UnityConfigurationFixture
    {
        [ClassInitialize]
        public static void SetupTests(TestContext context) => InitializeClass(context, "InjectingGenerics.config");

        [TestInitialize]
        public void SetupTest() => LoadContainer();

        [TestMethod]
        public void GenericParameterAsStringIsProperlySubstituted()
        {
            Container.RegisterType(typeof(GenericObjectWithConstructorDependency<>), "manual",
                new InjectionConstructor(new GenericParameter("T")));
            var manualResult = Container.Resolve<GenericObjectWithConstructorDependency<string>>("manual");

            var resultForString = Container.Resolve<GenericObjectWithConstructorDependency<string>>("basic");
            Assert.AreEqual(Container.Resolve<string>(), resultForString.Value);
        }

        [TestMethod]
        public void GenericParameterAsIntIsProperlySubstituted()
        {
            var resultForInt = Container.Resolve<GenericObjectWithConstructorDependency<int>>("basic");
            Assert.AreEqual(Container.Resolve<int>(), resultForInt.Value);
        }
    }
}
