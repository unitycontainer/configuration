using Microsoft.Practices.Unity.Configuration.Tests.TestObjects;
using Microsoft.Practices.Unity.TestSupport;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Configuration
{
    [TestClass]
    public class ConstructorsWithValuesInContainer : UnityConfigurationFixture
    {
        [ClassInitialize]
        public static void SetupTests(TestContext context) => InitializeClass(context, "VariousConstructors.config");

        [TestInitialize]
        public void SetupTest() => LoadContainer("constructorWithValue");

        [TestMethod]
        public void ConstructorGetsProperLiteralValuePassedFromChildElement()
        {
            var result = Container.Resolve<MockDatabase>("withExplicitValueElement");

            Assert.AreEqual("northwind", result.ConnectionString);
        }

        [TestMethod]
        public void ConstructorGetsProperResolvedDependency()
        {
            var result = Container.Resolve<MockDatabase>("resolvedWithName");

            Assert.AreEqual("adventureWorks", result.ConnectionString);
        }

        [TestMethod]
        public void ConstructorGetsProperResolvedDependencyViaAttribute()
        {
            var result = Container.Resolve<MockDatabase>("resolvedWithNameViaAttribute");

            Assert.AreEqual("contosoDB", result.ConnectionString);
        }

        [TestMethod]
        public void ValuesAreProperlyConvertedWhenTypeIsNotString()
        {
            var result = Container.Resolve<ObjectTakingScalars>("injectInt");

            Assert.AreEqual(17, result.IntValue);
        }

        [TestMethod]
        public void ConstructorGetsPropertyLiteralValueFromValueAttribute()
        {
            var result = Container.Resolve<ObjectTakingScalars>("injectIntWithValueAttribute");

            Assert.AreEqual(35, result.IntValue);
        }

        [TestMethod]
        public void TypeConverterIsUsedToGenerateConstructorValue()
        {
            var result = Container.Resolve<ObjectTakingScalars>("injectIntWithTypeConverter");

            Assert.AreEqual(-35, result.IntValue);
        }

        [TestMethod]
        public void TypeConverterIsUsedToGenerateConstructorValueViaAttribute()
        {
            var result = Container.Resolve<ObjectTakingScalars>("injectIntWithTypeConverterAttribute");

            Assert.AreEqual(-35, result.IntValue);
        }
    }
}
