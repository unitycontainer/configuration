

using System.Xml;

namespace Microsoft.Practices.Unity.Configuration
{
    internal interface IAttributeOnlyElement
    {
        void SerializeContent(XmlWriter writer);
    }
}
