using Microsoft.Practices.Unity.Configuration.Tests.TestObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ExtensionElementMap = Unity.Configuration.ExtensionElementMap;

namespace Microsoft.Practices
{
    [TestClass]
    public class SectionExtensions : MicrosoftPracticesFixture
    {
        [ClassInitialize]
        public static void SetupTests(TestContext context) => InitializeClass(context, "SectionExtensions.config");

        [TestMethod]
        public void ExpectedNumberOfSectionExtensionArePresent()
        {
            Assert.AreEqual(2, Section.SectionExtensions.Count);
        }

        [TestMethod]
        public void FirstSectionExtensionIsPresent()
        {
            Assert.AreEqual("TestSectionExtension", Section.SectionExtensions[0].TypeName);
            Assert.AreEqual(String.Empty, Section.SectionExtensions[0].Prefix);
        }

        [TestMethod]
        public void SecondSectionExtensionIsPresent()
        {
            Assert.AreEqual("TestSectionExtension", Section.SectionExtensions[1].TypeName);
            Assert.AreEqual("ext2", Section.SectionExtensions[1].Prefix);
        }

        [TestMethod]
        public void TestSectionExtensionWasInvokedOnce()
        {
            Assert.AreEqual(1, TestSectionExtension.NumberOfCalls);
        }

        [TestMethod]
        public void ContainerConfiguringExtensionElementsWereAdded()
        {
            Assert.AreEqual(typeof(ContainerConfigElementOne),
                ExtensionElementMap.GetContainerConfiguringElementType("configOne"));
            Assert.AreEqual(typeof(ContainerConfigElementTwo),
                ExtensionElementMap.GetContainerConfiguringElementType("configTwo"));
        }

        [TestMethod]
        public void PrefixedContainerConfiguringExtensionsWereAdded()
        {
            Assert.AreEqual(typeof(ContainerConfigElementOne),
                ExtensionElementMap.GetContainerConfiguringElementType("ext2.configOne"));
            Assert.AreEqual(typeof(ContainerConfigElementTwo),
                ExtensionElementMap.GetContainerConfiguringElementType("ext2.configTwo"));
        }

        [TestMethod]
        public void ValueElementWasAdded()
        {
            Assert.AreEqual(typeof(SeventeenValueElement),
                ExtensionElementMap.GetParameterValueElementType("seventeen"));
        }

        [TestMethod]
        public void UnprefixedAliasWasAdded()
        {
            string typeName = Section.TypeAliases["scalarObject"];
            Assert.IsNotNull(typeName);
            Assert.AreEqual(typeof(ObjectTakingScalars).AssemblyQualifiedName, typeName);
        }

        [TestMethod]
        public void PrefixedAliasWasAdded()
        {
            string typeName = Section.TypeAliases["ext2.scalarObject"];
            Assert.IsNotNull(typeName);
            Assert.AreEqual(typeof(ObjectTakingScalars).AssemblyQualifiedName, typeName);
        }
    }
}
