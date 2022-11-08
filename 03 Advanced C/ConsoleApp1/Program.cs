// See https://aka.ms/new-console-template for more information

namespace FileSystemVisitor;

public static class Program
{
    private static void Main(string[] args)
    {
        var path = string.Empty;

        var currentDirectory = Directory.GetCurrentDirectory();

        Console.WriteLine($"Please type the path that you want to evaluate its folders and files or press 'Enter' to evaluate current directory: {currentDirectory}.");
        path = Console.ReadLine();

        if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
        {
            path = currentDirectory;
        }

        Console.WriteLine("Type any string to filter directory content by that term, type 'Enter' to skip this filter.");
        var lookByTerm = Console.ReadLine();

        FileSystemVisitor fsv;
        if (string.IsNullOrEmpty(lookByTerm))
        {
        fsv = new FileSystemVisitor(path);
        }
        else
        {
            fsv = new FileSystemVisitor(path, OnlyElementsWithString);
        }

        Console.WriteLine(path);
        foreach (DirectoryElement element in fsv)
        {
            Console.Write("|");
            for (int depth = 1; depth <= element.DepthLevel; ++depth) Console.Write("-");
            Console.WriteLine($" {element.Name} is a {(element.ElementType == DirectoryElementType.Directory ? "Directory" : "File")}");
        }

        IEnumerable<DirectoryElement> OnlyElementsWithString(IEnumerable<DirectoryElement> contentFolder)
        {
            return contentFolder.Where(f => f.Name.Contains(lookByTerm, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}

public class FoldersFinderEventArgs : EventArgs
{
    public bool HasFilter { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public List<string> Folders = new();
    public List<string> FoldersBeforeFilter = new();
    public List<string> Files = new();
    public List<string> FilesBeforeFilter = new();
}
