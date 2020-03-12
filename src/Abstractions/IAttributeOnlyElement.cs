using System.Xml;

namespace Unity.Configuration.Abstractions
{
    internal interface IAttributeOnlyElement
    {
        void SerializeContent(XmlWriter writer);
    }
}
