using Microsoft.Practices.Unity.TestSupport;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Microsoft.Practices
{
    [TestClass]
    public class OldSyntax : MicrosoftPracticesFixture
    {
        [ClassInitialize]
        public static void SetupTests(TestContext context) => InitializeClass(context, "OldContainersSyntax.config");

        [TestMethod]
        public void SectionContainsExpectedNumberOfContainers()
        {
            Assert.AreEqual(2, Section.Containers.Count);
        }

        [TestMethod]
        public void ContainersArePresentInFileOrder()
        {
            CollectionAssertExtensions.AreEqual(new[] { String.Empty, "two" },
                Section.Containers.Select(c => c.Name).ToList());
        }
    }
}
