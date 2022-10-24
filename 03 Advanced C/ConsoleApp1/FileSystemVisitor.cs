namespace ConsoleApp1;

internal class FileSystemVisitor
{
    private readonly List<string> Folders;
    private readonly List<string> Files;

    public FileSystemVisitor(string path)
    {
        Folders = Directory.GetDirectories(path).ToList();
        Files = Directory.GetFiles(path).ToList();
    }

    public FileSystemVisitor(string path, Func<IEnumerable<string>, IEnumerable<string>> filterFunc) : this(path)
    {
        Files = filterFunc(Files).ToList();
        Folders = filterFunc(Folders).ToList();
    }

    public IEnumerable<string> GetFolders()
    {
        int index = 0;
        while (index < Folders.Count)
        {
            yield return Folders[index];
            index++;
        }
    }

    public IEnumerable<string> GetFiles()
    {
        int index = 0;
        while (index < Files.Count)
        {
            yield return Files[index];
            index++;
        }
    }
}
