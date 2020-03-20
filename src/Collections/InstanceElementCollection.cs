using System.Configuration;
using Unity.Configuration.Abstractions;

namespace Unity.Configuration
{
    /// <summary>
    /// A collection of <see cref="InstanceElement"/>s.
    /// </summary>
    [ConfigurationCollection(typeof(InstanceElement), AddItemName = "instance")]
    public class InstanceElementCollection : DeserializableConfigurationElementCollection<InstanceElement>
    {
        /// <summary>
        /// Gets the element key for a specified configuration element when overridden in a derived class.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Object"/> that acts as the key for the specified <see cref="T:System.Configuration.ConfigurationElement"/>.
        /// </returns>
        /// <param name="element">The <see cref="T:System.Configuration.ConfigurationElement"/> to return the key for. </param>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((InstanceElement)element).Key;
        }
    }
}
