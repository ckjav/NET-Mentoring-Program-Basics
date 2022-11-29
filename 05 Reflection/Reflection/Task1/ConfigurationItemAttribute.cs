using Microsoft.Extensions.Configuration;

namespace Task1;

[AttributeUsage(AttributeTargets.Property)]
public class ConfigurationItemAttribute : Attribute
{
    public string SettingName { get; set; }

    public ConfigurationItemAttribute(string settingName)
    {
        SettingName = settingName;
    }
}
