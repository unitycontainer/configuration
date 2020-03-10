using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity.Configuration.Tests;

namespace Microsoft.Practices.Tests
{
    public class MicrosoftPracticesFixture : ConfigFixtureBase
    {
        protected static Microsoft.Practices.Unity.Configuration.UnityConfigurationSection Section => 
            (Microsoft.Practices.Unity.Configuration.UnityConfigurationSection)Configuration.GetSection(SectionName);


        protected static void SetupTests(TestContext context, string configuration = null) => 
            SetupTests(context, typeof(Microsoft.Practices.Unity.Configuration.UnityConfigurationSection).Namespace, configuration);
    }
}
