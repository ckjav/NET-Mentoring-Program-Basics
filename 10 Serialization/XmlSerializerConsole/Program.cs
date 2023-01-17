using BaseLibrary;

namespace XmlSerializerConsole;

public class Program : Menu
{
    static readonly string filename = "department.xml";

    public static void Main()
    {
        var serializer = new Serializer(filename);
        DisplayOptionsForSerialization(serializer, filename);
    }
}