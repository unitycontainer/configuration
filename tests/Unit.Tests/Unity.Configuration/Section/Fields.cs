using Microsoft.Practices.Unity.TestSupport;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Unity.Configuration
{
    [TestClass]
    public class Fields : UnityConfigurationFixture
    {
        [ClassInitialize]
        public static void SetupTests(TestContext context) => InitializeClass(context, "Fields.config");

        [TestMethod]
        public void OneFieldElement()
        {
            var registration = (from reg in Section.Containers.Default.Registrations
                                where reg.TypeName == "ObjectWithTwoFields" && reg.Name == "singleField"
                                select reg).First();

            Assert.AreEqual(1, registration.InjectionMembers.Count);
            Assert.IsInstanceOfType(registration.InjectionMembers[0], typeof(FieldElement));
        }

        [TestMethod]
        public void TwoFieldElements()
        {
            var registration = (from reg in Section.Containers.Default.Registrations
                                where reg.TypeName == "ObjectWithTwoFields" && reg.Name == "twoFields"
                                select reg).First();

            Assert.AreEqual(2, registration.InjectionMembers.Count);
            Assert.IsTrue(registration.InjectionMembers.All(im => im is FieldElement));
        }

        [TestMethod]
        public void FieldNamesAreProperlyDeserialized()
        {
            var registration = (from reg in Section.Containers.Default.Registrations
                                where reg.TypeName == "ObjectWithTwoFields" && reg.Name == "twoFields"
                                select reg).First();

            CollectionAssertExtensions.AreEqual(new string[] { "Obj1", "Obj2" },
                registration.InjectionMembers.OfType<FieldElement>().Select(pe => pe.Name).ToList());
        }
    }
}
