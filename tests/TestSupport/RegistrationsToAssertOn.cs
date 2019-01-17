using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Unity;
using Unity.Lifetime;

namespace Microsoft.Practices.Unity.Configuration.Tests.TestSupport
{
    public class RegistrationsToAssertOn
    {
        public readonly IEnumerable<IContainerRegistration> Registrations;

        public RegistrationsToAssertOn(IEnumerable<IContainerRegistration> registrations)
        {
            this.Registrations = registrations;
        }

        public void HasLifetime<TLifetime>() where TLifetime : LifetimeManager
        {
            Assert.IsTrue(Registrations.All(r => r.LifetimeManager?.GetType() == typeof(TLifetime)));
        }
    }
}
