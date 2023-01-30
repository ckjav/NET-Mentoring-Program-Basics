using ConsoleLibrary.Domain.Contract;
using ConsoleLibrary.Model;

namespace ConsoleLibrary.Controller.Contract;

internal abstract class BaseDriver
{
    private readonly BaseStorageService _storage;

    protected BaseDriver(BaseStorageService storage)
    {
        _storage = storage ?? throw new ArgumentNullException("Storage should not be empty!");
    }

    public abstract void Print(string message);

    public abstract string Read();

    public BaseDocument? GetDocumentsByTitle(string documentId)
    {
        return _storage.GetDocument(documentId);
    }
}
