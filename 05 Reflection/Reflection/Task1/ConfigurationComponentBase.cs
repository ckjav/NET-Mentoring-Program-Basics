using Microsoft.Extensions.Configuration;

namespace Task1;

public class ConfigurationComponentBase : IConfigurationComponentBase
{
    [ConfigurationItem("some")]
    public bool StringProperty { get; set; }

    public void LoadSettings(IConfigurationProvider configurationProvider)
    {
        throw new NotImplementedException();
    }

    public void SaveSettings()
    {
        throw new NotImplementedException();
    }
}
