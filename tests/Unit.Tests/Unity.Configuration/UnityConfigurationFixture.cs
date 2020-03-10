using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity.Configuration.Tests;

namespace Unity.Configuration
{
    public class UnityConfigurationFixture : ConfigFixtureBase
    {
        protected static Unity.Configuration.UnityConfigurationSection Section =>
            (Unity.Configuration.UnityConfigurationSection)Configuration.GetSection(SectionName);


        protected static void SetupTests(TestContext context, string configuration = null) =>
            SetupTests(context, typeof(Unity.Configuration.UnityConfigurationSection).Namespace, configuration);
    }
}
