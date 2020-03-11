using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace Unity.Configuration.Tests
{
    public abstract class ConfigFixtureBase
    {
        #region Fields

        public const string TestConfiguration = "Configuration";
        public const string SectionName = "unity";
        public const string SectionType = "UnityConfigurationSection";
        public const string SectionAssembly = "Unity.Configuration";

        public const string NameAttribute = "name";
        public const string TypeAttribute = "type";

        protected static TestContext TestContext;

        #endregion


        #region Public Members

        protected static System.Configuration.Configuration Configuration => (System.Configuration.Configuration)TestContext.Properties[TestConfiguration];

        protected static ConfigurationSection GetSection(string name) => Configuration.GetSection(name);

        protected IUnityContainer Container { get; private set; }

        #endregion


        #region Implementation

        [ClassInitialize]
        protected static void InitializeClass(TestContext context, string @namespace, string configuration)
        {
            string path, name;
            TestContext = context;

            if (string.IsNullOrWhiteSpace(configuration))
            {
                name = $"{context.FullyQualifiedTestClassName}.config";
                path = Path.Combine(context.TestRunDirectory, name);
            }
            else
            {
                name = configuration.EndsWith(".config") ? $"Configurations.{configuration}" : $"Configurations.{configuration}.config";
                path = Path.Combine(context.TestRunDirectory, $"{context.FullyQualifiedTestClassName}.config");
            }

            var currentAssembly = Assembly.GetExecutingAssembly();
            var resourceNames = currentAssembly.GetManifestResourceNames();
            var resource = resourceNames.FirstOrDefault(it => it.EndsWith(name));

            if (null == resource)
            {
                throw new Exception($"Can not locate embedded resource '{name}'. \nAvailable choices are: \n{string.Join("\n", resourceNames)}");
            }
            
            XDocument doc = null;

            using (Stream resourceStream = currentAssembly.GetManifestResourceStream(resource))
            {
                doc = XDocument.Load(resourceStream);
            }


            foreach (var section in doc.Document.Element("configuration")
                                                .Element("configSections")
                                                .Descendants())
            {
                var attribute = section.Attribute(TypeAttribute);
                
                if (string.IsNullOrWhiteSpace(attribute.Value))
                    attribute.Value = $"{@namespace}.{SectionType}, {SectionAssembly}";
            }
            

            doc.Save(path);

            var fileMap = new ExeConfigurationFileMap
            {
                ExeConfigFilename = path
            };

            context.Properties[TestConfiguration] = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
        }

        protected virtual void CreateContainer()
        {
            if (null == Container) Container = new UnityContainer();
        }

        protected abstract void LoadContainer();

        protected abstract void LoadContainer(string name);

        protected abstract void LoadContainer(string section, string name);

        #endregion
    }
}
