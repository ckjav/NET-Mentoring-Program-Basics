namespace ConsoleLibrary.Model;

internal class Patent : BaseDocument
{
    public DateTime ExpirationDate { get; set; }

    public string UniqueId { get; set; }
}
