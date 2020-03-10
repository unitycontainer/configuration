using System.Xml;

namespace Unity.Configuration
{
    internal interface IAttributeOnlyElement
    {
        void SerializeContent(XmlWriter writer);
    }
}
