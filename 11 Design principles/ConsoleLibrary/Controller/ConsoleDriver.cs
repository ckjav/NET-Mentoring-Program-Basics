using ConsoleLibrary.Controller.Contract;
using ConsoleLibrary.Domain.Contract;

namespace ConsoleLibrary.Controller;

internal class ConsoleDriver : BaseDriver
{
    public ConsoleDriver(BaseStorageService storage) : base(storage)
    {

    }

    public override void Print(string message)
    {
        Console.WriteLine(message);
    }

    public override string Read()
    {
        var input = Console.ReadLine();
        return input;
    }
}
