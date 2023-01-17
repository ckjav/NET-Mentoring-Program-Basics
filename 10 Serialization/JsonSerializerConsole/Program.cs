using BaseLibrary;

namespace JsonSerializerConsole;

public class Program : Menu
{
    static readonly string filename = "department.json";

    public static void Main()
    {
        var serializer = new Serializer(filename);
        DisplayOptionsForSerialization(serializer, filename);
    }
}