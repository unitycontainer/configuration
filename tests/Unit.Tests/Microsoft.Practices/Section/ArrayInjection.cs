using Microsoft.Practices.Unity.TestSupport;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Unity.Configuration;

namespace Microsoft.Practices
{
    /// <summary>
    /// Summary description for When_LoadingConfigurationWithArrayInjection
    /// </summary>
    [TestClass]
    public class ArrayInjection : MicrosoftPracticesFixture
    {
        [ClassInitialize]
        public static void SetupTests(TestContext context) => InitializeClass(context, "ArrayInjection.config");

        [TestMethod]
        public void ArrayPropertyHasArrayElementAsValue()
        {
            var prop = GetArrayPropertyElement("specificElements");

            Assert.IsInstanceOfType(prop.Value, typeof(ArrayElement));
        }

        [TestMethod]
        public void ArrayPropertyHasTwoValuesThatWillBeInjected()
        {
            var prop = GetArrayPropertyElement("specificElements");
            var arrayValue = (ArrayElement)prop.Value;

            Assert.AreEqual(2, arrayValue.Values.Count);
        }

        [TestMethod]
        public void ArrayPropertyValuesAreAllDependencies()
        {
            var prop = GetArrayPropertyElement("specificElements");
            var arrayValue = (ArrayElement)prop.Value;

            Assert.IsTrue(arrayValue.Values.All(v => v is DependencyElement));
        }

        [TestMethod]
        public void ArrayPropertyValuesHaveExpectedNames()
        {
            var prop = GetArrayPropertyElement("specificElements");
            var arrayValue = (ArrayElement)prop.Value;

            CollectionAssertExtensions.AreEqual(new[] { "main", "special" },
                arrayValue.Values.Cast<DependencyElement>().Select(e => e.Name).ToList());
        }

        private PropertyElement GetArrayPropertyElement(string registrationName)
        {
            var registration = Section.Containers.Default.Registrations
                .Where(r => r.TypeName == "ArrayDependencyObject" && r.Name == registrationName)
                .First();

            return registration.InjectionMembers.OfType<PropertyElement>()
                .Where(pe => pe.Name == "Loggers")
                .First();
        }
    }
}
