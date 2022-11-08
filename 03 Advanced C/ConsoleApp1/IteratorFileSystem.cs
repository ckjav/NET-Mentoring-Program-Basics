using System.Collections;

namespace FileSystemVisitor;

public abstract class IteratorFileSystem : IEnumerable
{
    public abstract IEnumerator GetEnumerator();
}
