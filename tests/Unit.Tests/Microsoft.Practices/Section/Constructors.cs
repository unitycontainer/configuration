using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity.TestSupport;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Microsoft.Practices
{
    /// <summary>
    /// Summary description for When_LoadingConfigurationWithConstructors
    /// </summary>
    [TestClass]
    public class Constructors : MicrosoftPracticesFixture
    {
        private static ContainerElement ContainerElement;
        private static RegisterElement FirstRegistration;
        private static RegisterElement SecondRegistration;
        private static RegisterElement ThirdRegistration;

        [ClassInitialize]
        public static void SetupTests(TestContext context)
        {
            InitializeClass(context, "Constructors.config");

            ContainerElement          = Section.Containers.Default;
            FirstRegistration  = ContainerElement.Registrations[0];
            SecondRegistration = ContainerElement.Registrations[1];
            ThirdRegistration  = ContainerElement.Registrations[2];
        }

        [TestMethod]
        public void FirstRegistrationHasOneInjectionMember()
        {
            Assert.AreEqual(1, FirstRegistration.InjectionMembers.Count);
        }

        [TestMethod]
        public void FirstRegistrationHasConstructorMember()
        {
            Assert.IsInstanceOfType(FirstRegistration.InjectionMembers[0], typeof(ConstructorElement));
        }

        [TestMethod]
        public void FirstRegistrationConstructorHasExpectedParameters()
        {
            var constructorElement = (ConstructorElement)FirstRegistration.InjectionMembers[0];

            constructorElement.Parameters.Select(p => p.Name).AssertContainsExactly("one", "two", "three");
        }

        [TestMethod]
        public void SecondRegistrationHasNoInjectionMembers()
        {
            Assert.AreEqual(0, SecondRegistration.InjectionMembers.Count);
        }

        [TestMethod]
        public void ThirdRegistrationHasZeroArgConstructor()
        {
            Assert.AreEqual(0,
                ((ConstructorElement)ThirdRegistration.InjectionMembers[0]).Parameters.Count);
        }
    }
}
