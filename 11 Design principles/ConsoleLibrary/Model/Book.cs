namespace ConsoleLibrary.Model;

internal class Book : BaseDocument
{
    public string ISBN { get; set; }

    public int NumberOfPages { get; set; }

    public string Publisher { get; set; }
}
