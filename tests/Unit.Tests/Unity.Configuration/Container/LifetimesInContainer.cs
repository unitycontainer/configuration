using Microsoft.Practices.Unity.Configuration.Tests.TestSupport;
using Microsoft.Practices.Unity.TestSupport;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Unity.Lifetime;

namespace Unity.Configuration
{
    [TestClass]
    public class LifetimesInContainer : UnityConfigurationFixture
    {
        [ClassInitialize]
        public static void SetupTests(TestContext context) => InitializeClass(context, "Lifetimes.config");

        [TestInitialize]
        public void SetupTest() => LoadContainer();

        [TestMethod]
        public void BaseILoggerHasSingletonLifetime()
        {
            AssertRegistration<ILogger>(null).HasLifetime<ContainerControlledLifetimeManager>();
        }

        [TestMethod]
        public void MockLoggerHasExternalLifetime()
        {
            AssertRegistration<ILogger>("mock").HasLifetime<ExternallyControlledLifetimeManager>();
        }

        [TestMethod]
        public void SessionLoggerHasSessionLifetime()
        {
            AssertRegistration<ILogger>("session").HasLifetime<SessionLifetimeManager>();
        }

        [TestMethod]
        public void ReverseSessionLoggerHasSessionLifetime()
        {
            AssertRegistration<ILogger>("reverseSession").HasLifetime<SessionLifetimeManager>();
        }

        [TestMethod]
        public void ReverseSessionLoggerLifetimeWasInitializedUsingTypeConverter()
        {
            AssertRegistration<ILogger>("reverseSession").LifetimeHasSessionKey("sdrawkcab");
        }

        [TestMethod]
        public void RegistrationWithoutExplicitLifetimeIsTransient()
        {
            AssertRegistration<ILogger>("transient").HasLifetime<TransientLifetimeManager>();
        }

        [TestMethod]
        public void RegistrationWithEmptyLifetimeTypeIsTransient()
        {
            AssertRegistration<ILogger>("explicitTransient").HasLifetime<TransientLifetimeManager>();
        }

        private RegistrationsToAssertOn AssertRegistration<TRegisterType>(string registeredName)
        {
            return new RegistrationsToAssertOn(
                Container.Registrations
                    .Where(r => r.RegisteredType == typeof(TRegisterType) && r.Name == registeredName));
        }
    }

    internal static partial class RegistrationsToAssertOnExtensions
    {
        public static void LifetimeHasSessionKey(this RegistrationsToAssertOn r, string sessionKey)
        {
            Assert.IsTrue(
                r.Registrations.All(reg => ((SessionLifetimeManager)reg.LifetimeManager).SessionKey == sessionKey));
        }
    }
}
