using ConsoleLibrary.Controller;
using ConsoleLibrary.Controller.Contract;
using ConsoleLibrary.Domain;
using ConsoleLibrary.Domain.Contract;

namespace ConsoleLibrary;

public static class Program
{
    public static void Main(string[] args)
    {
        BaseStorageService storage = new FileService();
        BaseDriver driver = new ConsoleDriver(storage);
        driver.Print("Please, type the title you're looking for:");
        var input = driver.Read();
        var document = driver.GetDocumentsByTitle(input);

        if(document == null)
        {
            driver.Print("Book wasn't found");
        }
        else
        {
            driver.Print($"The document {input} you're has the title: {document.Title}");
        }
    }
}