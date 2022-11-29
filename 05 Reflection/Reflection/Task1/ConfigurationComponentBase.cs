using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Task1;

public class ConfigurationComponentBase// : IConfigurationComponentBase
{
    [ConfigurationItem("assemblies")]
    [JsonPropertyName("assemblies")]
    [XmlAttribute(AttributeName = "name")]
    public IEnumerable<ConfigurationComponentElement> Assemblies { get; set; }
}

public class ConfigurationComponentElement
{
    [ConfigurationItem("nameCustom")]
    [JsonPropertyName("nameJson")]
    [XmlAttribute(AttributeName = "nameXml")]
    public string Name { get; set; }
}