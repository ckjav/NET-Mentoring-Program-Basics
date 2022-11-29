using System.Collections;

namespace FileSystemVisitor;

public class FileSystemIterator : IEnumerator
{
    private int _position = -1;
    private readonly List<DirectoryElement> _directoryElements;

    public FileSystemIterator(List<DirectoryElement> directoryElements)
    {
        _directoryElements = directoryElements;
    }

    public object Current => _directoryElements[_position];

    public bool MoveNext()
    {
        ++this._position;
        return this._position < this._directoryElements.Count;
    }

    public void Reset()
    {
        this._position = -1;
    }
}
