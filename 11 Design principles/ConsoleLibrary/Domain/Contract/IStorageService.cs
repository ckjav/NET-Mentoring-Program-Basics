using ConsoleLibrary.Model;

namespace ConsoleLibrary.Domain.Contract;

internal abstract class BaseStorageService
{
    public abstract BaseDocument GetDocument(string documentId);
}
