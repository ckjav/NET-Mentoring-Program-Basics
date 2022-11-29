using System.Text.Json;
using Task1;

namespace Task1Console;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Load configuration file, please type your option:");
        Console.WriteLine("1 for JSON");
        Console.WriteLine("2 for XML");
        var input = Console.ReadKey();
        Console.WriteLine();

        ConfigurationComponentBase? assemblies;

        switch (input.KeyChar)
        {
            case '1':
                assemblies = LoadJsonSettings();
                break;
            case '2':
                assemblies = LoadXMLSettings();
                break;
            default:
                NotValidOption();
                return;
        }

        if(assemblies == null)
        {
            Console.WriteLine("There are no elements at settings file.");
            Console.WriteLine("Press any key to exit.");
            return;
        }

        foreach (var assembly in assemblies.Assemblies)
        {
            Console.WriteLine($"Assembly: {assembly.Name}");
        }
    }

    public static ConfigurationComponentBase? LoadJsonSettings()
    {
        var filename = "settings.json";

        return OpenFile(filename, "JSON");
    }

    public static ConfigurationComponentBase? LoadXMLSettings()
    {
        var filename = "settings.xml";

        return OpenFile(filename, "XML");
    }

    private static ConfigurationComponentBase? OpenFile(string filename, string fileType)
    {
        var currentDirectory = System.IO.Directory.GetCurrentDirectory();
        if (!File.Exists(currentDirectory + "\\" + filename))
        {
            Console.WriteLine($"{fileType} settings file was removed or renamed, please restore it.");
            return default;
        }

        using var file = File.OpenRead(filename);
        using var reader = new StreamReader(file);
        var json = reader.ReadToEnd();

        return JsonSerializer.Deserialize<ConfigurationComponentBase>(json);
    }

    public static void NotValidOption()
    {
        Console.WriteLine("You didn't selected a valid option, please run again.");
        Console.WriteLine("Type any key to exit.");
        Console.ReadKey();
    }
}