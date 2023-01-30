namespace ConsoleLibrary.Model;

internal abstract class BaseDocument
{
    public string Title { get; set; }

    public string Authors { get; set; }

    public DateTime DatePublished { get; set; }
}
