namespace ConsoleApp1;

internal class FileSystemVisitor
{
    private readonly string _path;
    private readonly bool _hasFilter;
    private bool _executed;
    private List<string> _folders;
    private IEnumerable<string> _foldersBeforeFilter;
    private List<string> _files = new();
    private IEnumerable<string> _filesBeforeFilter;
    private readonly Func<IEnumerable<string>, IEnumerable<string>> _filter;

    public event EventHandler<FoldersFinderEventArgs> Finder;


    public FileSystemVisitor(string path)
    {
        _executed = false;
        _path = path;
        _folders = new List<string>();
        _files = new List<string>();
    }

    public FileSystemVisitor(string path, Func<IEnumerable<string>, IEnumerable<string>> filterFunc) : this(path)
    {
        _filter = filterFunc;
        _hasFilter = true;
    }

    public IEnumerable<string> GetFolders()
    {
        GetFolderContent();

        int index = 0;
        while (index < _folders.Count)
        {
            yield return _folders[index];
            index++;
        }
    }

    public IEnumerable<string> GetFiles()
    {
        GetFolderContent();

        int index = 0;
        while (index < _files.Count)
        {
            yield return _files[index];
            index++;
        }
    }

    protected virtual void OnFolderFinderFinished(FoldersFinderEventArgs e)
    {
        EventHandler<FoldersFinderEventArgs> handler = Finder;
        if (handler != null)
        {
            handler(this, e);
        }
    }

    private void GetFolderContent()
    {
        if (_executed) return;

        _executed = true;
        FoldersFinderEventArgs args = new FoldersFinderEventArgs();
        args.Start = DateTime.Now;

        var folders = Directory.GetDirectories(_path).ToList();
        var files = Directory.GetFiles(_path).ToList();
        _folders.AddRange(folders);
        _files.AddRange(files);

        LookInSubfolder(folders);

        if (_hasFilter)
        {
            _foldersBeforeFilter = _folders.Select(x => x);
            _filesBeforeFilter = _files.Select(x => x);
            _folders = _filter(_folders).ToList();
            _files = _filter(_files).ToList();

            args.HasFilter = true;
            args.FoldersBeforeFilter.AddRange(_foldersBeforeFilter);
            args.FilesBeforeFilter.AddRange(_filesBeforeFilter);
        }

        args.Folders= _folders;
        args.Files = _files;
        args.End = DateTime.Now;

        OnFolderFinderFinished(args);
    }

    private void LookInSubfolder(IEnumerable<string> folders)
    {
        foreach (var _ in folders)
        {
            var subFolders = Directory.GetDirectories(_);
            var subfolderFiles = Directory.GetFiles(_).ToList();
            _folders.AddRange(subFolders);
            _files.AddRange(subfolderFiles);

            LookInSubfolder(subFolders);
        }
    }
}
