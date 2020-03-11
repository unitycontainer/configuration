using Microsoft.Practices.Unity.TestSupport;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Microsoft.Practices
{
    [TestClass]
    public class Instances : MicrosoftPracticesFixture
    {
        [ClassInitialize]
        public static void SetupTests(TestContext context) => InitializeClass(context, "RegisteringInstances.config");

        [TestMethod]
        public void ContainerHasExpectedInstancesElements()
        {
            Assert.AreEqual(4, Section.Containers.Default.Instances.Count);
        }

        [TestMethod]
        public void InstancesHaveExpectedContents()
        {
            var expected = new[]
                {
                    // Name, InjectionParameterValue, Type, TypeConverter
                    new[] { String.Empty, "AdventureWorks", String.Empty, String.Empty },
                    new[] { String.Empty, "42", "System.Int32", String.Empty },
                    new[] { "negated", "23", "int", "negator" },
                    new[] { "forward", "23", "int", String.Empty }
                };

            for (int index = 0; index < expected.Length; ++index)
            {
                var instance = Section.Containers.Default.Instances[index];
                CollectionAssertExtensions.AreEqual(expected[index],
                    new string[] { instance.Name, instance.Value, instance.TypeName, instance.TypeConverterTypeName },
                    string.Format("Element at index {0} does not match", index));
            }
        }
    }
}
