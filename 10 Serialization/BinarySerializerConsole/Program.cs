using BaseLibrary;

namespace BinarySerializerConsole;

public class Program : Menu
{
    static readonly string filename = "department.bin";

    public static void Main(string[] args)
    {
        var serializer = new Serializer(filename);
        DisplayOptionsForSerialization(serializer, filename);
    }
}
