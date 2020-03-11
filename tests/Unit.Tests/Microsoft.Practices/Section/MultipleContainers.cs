using Microsoft.Practices.Unity.TestSupport;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Microsoft.Practices
{
    /// <summary>
    /// Summary description for When_LoadingConfigWithMultipleContainers
    /// </summary>
    [TestClass]
    public class MultipleContainers : MicrosoftPracticesFixture
    {
        [ClassInitialize]
        public static void SetupTests(TestContext context) => InitializeClass(context, "SingleSectionMultipleNamedContainers.config");

        [TestMethod]
        public void ExpectedNumberOfContainersArePresent()
        {
            Assert.AreEqual(2, Section.Containers.Count);
        }

        [TestMethod]
        public void FirstContainerNameIsCorrect()
        {
            Assert.AreEqual("one", Section.Containers[0].Name);
        }

        [TestMethod]
        public void SecondContainerNameIsCorrect()
        {
            Assert.AreEqual("two", Section.Containers[1].Name);
        }

        [TestMethod]
        public void EnumeratingContainersHappensInOrderOfConfigFile()
        {
            CollectionAssertExtensions.AreEqual(new[] { "one", "two" },
                Section.Containers.Select(c => c.Name).ToList());
        }
    }
}
