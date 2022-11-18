using Microsoft.Extensions.Configuration;

namespace Task1;

[AttributeUsage(AttributeTargets.Property)]
public class ConfigurationItemAttribute : Attribute
{
    private readonly object _value;

    public string SettingName { get; set; }

    public IConfiguration ProviderType { get; set; }

    public object Value
    {
        get
        {
            return _value;
        }
    }

    public ConfigurationItemAttribute() { }

    public ConfigurationItemAttribute(string value)
    {
        _value = value;
    }

}
