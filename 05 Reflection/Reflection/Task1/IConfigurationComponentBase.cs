using Microsoft.Extensions.Configuration;

namespace Task1;

public interface IConfigurationComponentBase
{
    void SaveSettings();

    void LoadSettings(IConfigurationProvider configurationProvider);
}
