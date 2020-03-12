using Microsoft.Practices.Unity.TestSupport;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Unity.Configuration;

namespace Microsoft.Practices
{
    [TestClass]
    public class Properties : MicrosoftPracticesFixture
    {
        [ClassInitialize]
        public static void SetupTests(TestContext context) => InitializeClass(context, "Properties.config");

        [TestMethod]
        public void RegistrationHasOnePropertyElement()
        {
            var registration = (from reg in Section.Containers.Default.Registrations
                                where reg.TypeName == "ObjectWithTwoProperties" && reg.Name == "singleProperty"
                                select reg).First();

            Assert.AreEqual(1, registration.InjectionMembers.Count);
            Assert.IsInstanceOfType(registration.InjectionMembers[0], typeof(PropertyElement));
        }

        [TestMethod]
        public void RegistrationHasTwoPropertyElements()
        {
            var registration = (from reg in Section.Containers.Default.Registrations
                                where reg.TypeName == "ObjectWithTwoProperties" && reg.Name == "twoProperties"
                                select reg).First();

            Assert.AreEqual(2, registration.InjectionMembers.Count);
            Assert.IsTrue(registration.InjectionMembers.All(im => im is PropertyElement));
        }

        [TestMethod]
        public void PropertyNamesAreProperlyDeserialized()
        {
            var registration = (from reg in Section.Containers.Default.Registrations
                                where reg.TypeName == "ObjectWithTwoProperties" && reg.Name == "twoProperties"
                                select reg).First();

            CollectionAssertExtensions.AreEqual(new string[] { "Obj1", "Obj2" },
                registration.InjectionMembers.OfType<PropertyElement>().Select(pe => pe.Name).ToList());
        }
    }
}
