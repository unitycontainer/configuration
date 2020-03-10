using Microsoft.Practices.Unity.TestSupport;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Unity.Configuration
{
    [TestClass]
    public class OldContainersSyntax : UnityConfigurationFixture
    {
        [ClassInitialize]
        public static void SetupTests(TestContext context)
        {
            SetupTests(context, "OldContainersSyntax.config");
        }

        [TestMethod]
        public void Then_SectionContainsExpectedNumberOfContainers()
        {
            Assert.AreEqual(2, Section.Containers.Count);
        }

        public void Then_ContainersArePresentInFileOrder()
        {
            CollectionAssertExtensions.AreEqual(new[] { String.Empty, "two" },
                Section.Containers.Select(c => c.Name).ToList());
        }
    }
}
