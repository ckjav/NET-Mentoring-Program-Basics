using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BaseLibrary;

namespace BinarySerializerConsole;

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
            IFormatter formatter = new BinaryFormatter();
            using Stream stream = new FileStream(_filename, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, department);
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
            IFormatter formatter = new BinaryFormatter();
            using Stream stream = new FileStream(_filename, FileMode.Open, FileAccess.Read, FileShare.None);
            var department = (Department)formatter.Deserialize(stream);
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
