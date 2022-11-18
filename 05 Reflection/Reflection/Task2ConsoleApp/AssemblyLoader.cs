using System.Reflection;

namespace Task2ConsoleApp;

public class AssemblyLoader : ICommand
{
    public void Execute()
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        var pluginsDirectory = currentDirectory + @"\plugins";
        Directory.CreateDirectory(pluginsDirectory);

        Console.WriteLine($"Current working directory it's: {currentDirectory}");
        Console.WriteLine($"Please put some Assemblies (*.dll) in plugins folder.");
        Console.WriteLine("They will be loaded and its types will be displayed.");
        Console.WriteLine("After you copy files, please type any key to continue.");
        Console.ReadKey();

        if (!Directory.Exists(pluginsDirectory))
        {
            Console.WriteLine("'plugins' folder has been deleted or renamed, run again to create again 'plugins' folder.");
            Console.WriteLine("This window will be closed, press any key to continue.");
            Console.ReadKey();
        }

        var files = Directory.GetFiles(pluginsDirectory, "*.dll");

        if (!files.Any())
        {
            Console.WriteLine("There are no assemblies in directory, please any key to exit.");
            Console.ReadKey();
            return;
        }

        foreach (var file in files)
        {
            var assembly = Assembly.LoadFrom(file);

            Console.WriteLine($"Assembly {assembly.GetName()} has been loaded, its types are:");
            foreach (var type in assembly.GetTypes())
            {
                Console.WriteLine($"- {type}");
            }
        }
    }
}
