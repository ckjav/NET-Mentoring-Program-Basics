// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

var path = string.Empty;

do
{
    Console.WriteLine("Please type the path that you want to evaluate its folders and files");
    path = Console.ReadLine();
} while (string.IsNullOrEmpty(path));

//var fileSystemVisitor = new FileSystemVisitor(path);
//fileSystemVisitor.Finder += c_FolderFinderFinished;
//PrintResult(fileSystemVisitor);


var fileSystemVisitorWithCarrot = new FileSystemVisitor(path, OnlyElementsWithCarrot);
fileSystemVisitorWithCarrot.Finder += c_FolderFinderFinished;
PrintResult(fileSystemVisitorWithCarrot, "Path contains the next folders that contains 'carrot': ");


void PrintResult(FileSystemVisitor fsv, string filter = "")
{
    Console.WriteLine("Would you see folder list, type y/s: ");
    var response = Console.ReadKey();
    Console.WriteLine("");
    var folders = fsv.GetFolders();
    var files = fsv.GetFiles();

    if (response.KeyChar.Equals('y'))
    {
        if (!string.IsNullOrEmpty(filter))
        {
            Console.WriteLine(filter);
        }

        foreach (var _ in folders)
        {
            Console.WriteLine(_);
        }
        foreach (var _ in files)
        {
            Console.WriteLine(_);
        }
    }
    else
    {
        Console.WriteLine("There are {0} folders and {1} files.", folders.Count(), files.Count());
    }
}


IEnumerable<string> OnlyElementsWithCarrot(IEnumerable<string> files)
{
    return files.Where(f => f.Contains("carrot", StringComparison.InvariantCultureIgnoreCase));
}

static void c_FolderFinderFinished(object sender, FoldersFinderEventArgs e)
{
    Console.WriteLine("Started at {0} and finished at {1}", e.Start, e.End);
    Console.WriteLine("Contains {0} folders and {1} files", e.Folders.Count, e.Files.Count);
    if(e.HasFilter) Console.WriteLine("Before filtering, there are {0} folders and {1} files", e.FoldersBeforeFilter.Count, e.FilesBeforeFilter.Count);
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