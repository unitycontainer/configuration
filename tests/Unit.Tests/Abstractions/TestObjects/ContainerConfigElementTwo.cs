using Unity;
using Unity.Configuration.Abstractions;

namespace Microsoft.Practices.Unity.Configuration.Tests.TestObjects
{
    internal class ContainerConfigElementTwo : ContainerConfiguringElement
    {
        public static bool ConfigureWasCalled;

        /// <summary>
        /// Apply this element's configuration to the given <paramref name="container"/>.
        /// </summary>
        /// <param name="container">Container to configure.</param>
        protected override void ConfigureContainer(IUnityContainer container)
        {
            ConfigureWasCalled = true;
        }
    }
}
