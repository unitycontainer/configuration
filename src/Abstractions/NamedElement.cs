using System;
using System.Configuration;
using System.Xml;

namespace Unity.Configuration.Abstractions
{
    /// <summary>
    /// An element with a single "name" property, used for
    /// the namespaces and assemblies.
    /// </summary>
    public abstract class NamedElement : DeserializableConfigurationElement
    {
        private const string NamePropertyName = "name";

        /// <summary>
        /// Name attribute for this element.
        /// </summary>
        [ConfigurationProperty(NamePropertyName, IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return (string)base[NamePropertyName]; }
            set { base[NamePropertyName] = value; }
        }

        /// <summary>
        /// Write the contents of this element to the given <see cref="XmlWriter"/>.
        /// </summary>
        /// <remarks>The caller of this method has already written the start element tag before
        /// calling this method, so deriving classes only need to write the element content, not
        /// the start or end tags.</remarks>
        /// <param name="writer">Writer to send XML content to.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods",
            Justification = "Validation done by Guard class")]
        public override void SerializeContent(XmlWriter writer)
        {
            if (null == writer) throw new ArgumentNullException(nameof(writer));
            
            writer.WriteAttributeString(NamedElement.NamePropertyName, this.Name);
        }
    }
}
