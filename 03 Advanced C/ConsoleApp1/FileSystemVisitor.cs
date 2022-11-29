using System.Collections;

namespace FileSystemVisitor;

public class FileSystemVisitor : IteratorFileSystem
{
    private readonly List<DirectoryElement> _directoryElements = new List<DirectoryElement>();

    public event EventHandler<FoldersFinderEventArgs> Finder;


    public FileSystemVisitor(string path)
    {
        _directoryElements = InspectFolderContent(path, 1);
    }

    public FileSystemVisitor(string path, Func<IEnumerable<DirectoryElement>, IEnumerable<DirectoryElement>> filterFunc) : this(path)
    {
        _directoryElements = filterFunc(_directoryElements).ToList();
    }

    protected virtual void OnFolderFinderFinished(FoldersFinderEventArgs e)
    {
        EventHandler<FoldersFinderEventArgs> handler = Finder;
        if (handler != null)
        {
            handler(this, e);
        }
    }

    private List<DirectoryElement> InspectFolderContent(string _path, int depthLevel = 1)
    {

        var files = Directory.GetFiles(_path);
        if (files.Any())
        {
            foreach (var file in files)
            {
                _directoryElements.Add(new DirectoryElement
                {
                    ElementType = DirectoryElementType.File,
                    Name = file.Replace(_path + "\\", string.Empty),
                    DepthLevel = depthLevel
                });
            }
        }

        var folders = Directory.GetDirectories(_path);
        if (folders.Any())
        {
            foreach (var folder in folders)
            {
                _directoryElements.Add(new DirectoryElement
                {
                    ElementType = DirectoryElementType.Directory,
                    Name = folder.Replace(_path + "\\", string.Empty),
                    DepthLevel = depthLevel
                });
                InspectFolderContent(folder, depthLevel + 1);
            }
        }

        return _directoryElements;
    }

    public override IEnumerator GetEnumerator()
    {
        return new FileSystemIterator(_directoryElements);
    }


}
