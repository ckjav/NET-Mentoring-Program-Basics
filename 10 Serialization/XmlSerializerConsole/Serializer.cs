using BaseLibrary;
using System.Xml.Serialization;

namespace XmlSerializerConsole;

public class Serializer : Menu, ISerializerApp
{
    private readonly string _filename;

    public Serializer(string filename)
    {
        _filename = filename;
    }

    public void Serialize()
    {
        var department = Seeder.GetDepartment();

        DisplayEntryMessage();
        DisplayDepartmentInfo(department);

        try
        {
            XmlSerializer serializer = new(typeof(Department));
            using Stream stream = new FileStream(_filename, FileMode.Create, FileAccess.Write, FileShare.None);
            serializer.Serialize(stream, department);
            stream.Close();
            DisplayFileCreationMessage(_filename);
        }
        catch
        {
            DisplayWritingFileErrorMessage();
            throw;
        }
    }

    public void Deserialize()
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        if (!ValidateFilePath(currentDirectory, _filename))
        {
            return;
        }

        Console.WriteLine($"Deserializing file {_filename}");

        try
        {
            XmlSerializer serializer = new(typeof(Department));
            using Stream stream = new FileStream(_filename, FileMode.Open, FileAccess.Read, FileShare.None);
            var department = (Department?)serializer.Deserialize(stream);
            stream.Close();

            Console.WriteLine("File had been deserialized.");
            DisplayDepartmentInfo(department);
        }
        catch
        {
            DisplayReadingFileErrorMessage(_filename);
            throw;
        }
    }
}
