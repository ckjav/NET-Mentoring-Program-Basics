using Microsoft.Extensions.Configuration;

namespace Task1.Contracts;

public interface IConfigurationComponentBase
{
    void SaveSettings();

    void LoadSettings(IConfigurationProvider configurationProvider);
}
