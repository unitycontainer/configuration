using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity.Configuration.Tests;
using Microsoft.Practices.Unity.Configuration;

namespace Microsoft.Practices
{
    public abstract class MicrosoftPracticesFixture : ConfigFixtureBase
    {
        protected static UnityConfigurationSection Section { get; private set; }

        protected static void InitializeClass(TestContext context, string configuration = null)
        {
            InitializeClass(context, typeof(UnityConfigurationSection).Namespace, configuration);
            Section = (UnityConfigurationSection)Configuration.GetSection(SectionName);
        }

        protected override void LoadContainer()
        {
            base.CreateContainer();
            Section.Configure(Container);
        }

        protected override void LoadContainer(string name)
        {
            base.CreateContainer();
            Section.Configure(Container, name);
        }

        protected override void LoadContainer(string section, string name)
        {
            base.CreateContainer();
            ((UnityConfigurationSection)Configuration.GetSection(section)).Configure(Container, name);
        }
    }
}
