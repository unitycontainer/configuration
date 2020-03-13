using System;
using System.Configuration;
using System.Linq;
using System.Xml;
using Unity.Configuration.Abstractions;
using Unity.Configuration.Extensions;
using Unity.Configuration.Storage;

namespace Unity.Configuration
{
    /// <summary>
    /// A configuration element class defining the set of registrations to be
    /// put into a container.
    /// </summary>
    public class ContainerElement : DeserializableConfigurationElement
    {
        #region Constants

        private const string NameConst          = "name";
        private const string InstancesConst     = "instances";
        private const string ExtensionsConst    = "extensions";
        private const string RegistrationsConst = "";

        #endregion


        #region Fields

        private static ConfigurationPropertyCollection _properties;

        #endregion


        #region Constructors

        static ContainerElement()
        {
            _properties = new ConfigurationPropertyCollection()
            { 
                new ConfigurationProperty(NameConst,            typeof(string),                     "",   ConfigurationPropertyOptions.IsKey),
                new ConfigurationProperty(RegistrationsConst,   typeof(RegisterElementCollection),  null, ConfigurationPropertyOptions.IsDefaultCollection),
                new ConfigurationProperty(InstancesConst,       typeof(InstanceElementCollection)),
                new ConfigurationProperty(ExtensionsConst,      typeof(ContainerExtensionElementCollection))
            };
        }

        #endregion

        //protected override ConfigurationPropertyCollection Properties => _properties;


        private static readonly ElementHandlerMap<ContainerElement> UnknownElementHandlerMap =
            new ElementHandlerMap<ContainerElement>
                {
                    { "types", (ce, xr) => ce.Registrations.Deserialize(xr) },
                    { "extension", (ce, xr) => ce.ReadUnwrappedElement(xr, ce.Extensions) },
                    { "instance", (ce, xr) => ce.ReadUnwrappedElement(xr, ce.Instances) }
                };

        private readonly ContainerConfiguringElementCollection configuringElements = new ContainerConfiguringElementCollection();

        internal ConfigurationSection ContainingSection { get; set; }

        /// <summary>
        /// Name for this container configuration as given in the config file.
        /// </summary>
        [ConfigurationProperty(NameConst, IsKey = true, DefaultValue = "")]
        public string Name
        {
            get { return (string)base[NameConst]; }
            set { base[NameConst] = value; }
        }

        /// <summary>
        /// The type registrations in this container.
        /// </summary>
        [ConfigurationProperty(RegistrationsConst, IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(RegisterElement), AddItemName = "register")]
        public RegisterElementCollection Registrations
        {
            get { return (RegisterElementCollection)base[RegistrationsConst]; }
        }

        /// <summary>
        /// Any instances to register in the container.
        /// </summary>
        [ConfigurationProperty(InstancesConst)]
        [ConfigurationCollection(typeof(InstanceElement), AddItemName = "instance")]
        public InstanceElementCollection Instances
        {
            get { return (InstanceElementCollection)base[InstancesConst]; }
        }

        /// <summary>
        /// Any extensions to add to the container.
        /// </summary>
        [ConfigurationProperty(ExtensionsConst)]
        [ConfigurationCollection(typeof(ContainerExtensionElement))]
        public ContainerExtensionElementCollection Extensions
        {
            get { return (ContainerExtensionElementCollection)base[ExtensionsConst]; }
        }

        /// <summary>
        /// Set of any extra configuration elements that were added by a
        /// section extension.
        /// </summary>
        /// <remarks>
        /// This is not marked as a configuration property because we don't want
        /// the actual property to show up as a nested element in the configuration.</remarks>
        public ContainerConfiguringElementCollection ConfiguringElements
        {
            get { return configuringElements; }
        }

        /// <summary>
        /// Apply the configuration information in this element to the
        /// given <paramref name="container"/>.
        /// </summary>
        /// <param name="container">Container to configure.</param>
        internal void ConfigureContainer(IUnityContainer container)
        {
            foreach (var element in Extensions.Cast<ContainerConfiguringElement>()
                                             .Concat(Registrations.Cast<ContainerConfiguringElement>())
                                             .Concat(Instances.Cast<ContainerConfiguringElement>())
                                             .Concat(ConfiguringElements))
            {
                element.ConfigureContainerInternal(container);
            }
        }

        /// <summary>
        /// Gets a value indicating whether an unknown element is encountered during deserialization.
        /// </summary>
        /// <returns>
        /// true when an unknown element is encountered while deserializing; otherwise, false.
        /// </returns>
        /// <param name="elementName">The name of the unknown subelement.</param>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader"/> being used for deserialization.</param>
        /// <exception cref="T:System.Configuration.ConfigurationErrorsException">The element identified by <paramref name="elementName"/> is locked.
        /// - or -
        /// One or more of the element's attributes is locked.
        /// - or -
        /// <paramref name="elementName"/> is unrecognized, or the element has an unrecognized attribute.
        /// - or -
        /// The element has a Boolean attribute with an invalid value.
        /// - or -
        /// An attempt was made to deserialize a property more than once.
        /// - or -
        /// An attempt was made to deserialize a property that is not a valid member of the element.
        /// - or -
        /// The element cannot contain a CDATA or text element.
        /// </exception>
        protected override bool OnDeserializeUnrecognizedElement(string elementName, XmlReader reader)
        {
            return UnknownElementHandlerMap.ProcessElement(this, elementName, reader) ||
                DeserializeContainerConfiguringElement(elementName, reader) ||
                base.OnDeserializeUnrecognizedElement(elementName, reader);
        }

        /// <summary>
        /// Write the contents of this element to the given <see cref="XmlWriter"/>.
        /// </summary>
        /// <remarks>The caller of this method has already written the start element tag before
        /// calling this method, so deriving classes only need to write the element content, not
        /// the start or end tags.</remarks>
        /// <param name="writer">Writer to send XML content to.</param>
        public override void SerializeContent(XmlWriter writer)
        {
            writer.WriteAttributeIfNotEmpty(ContainerElement.NameConst, Name);

            Extensions.SerializeElementContents(writer, "extension");
            Registrations.SerializeElementContents(writer, "register");
            Instances.SerializeElementContents(writer, "instance");
            SerializeContainerConfiguringElements(writer);
        }

        private bool DeserializeContainerConfiguringElement(string elementName, XmlReader reader)
        {
            Type elementType = ExtensionElementMap.GetContainerConfiguringElementType(elementName);
            if (elementType != null)
            {
                this.ReadElementByType(reader, elementType, ConfiguringElements);
                return true;
            }
            return false;
        }

        private void SerializeContainerConfiguringElements(XmlWriter writer)
        {
            foreach (var element in ConfiguringElements)
            {
                string tag = ExtensionElementMap.GetTagForExtensionElement(element);
                writer.WriteElement(tag, element.SerializeContent);
            }
        }
    }
}
