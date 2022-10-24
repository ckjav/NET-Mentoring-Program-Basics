// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

var path = string.Empty;

do
{
    Console.WriteLine("Please type the path that you want to evaluate its folders and files");
    path = Console.ReadLine();
} while (string.IsNullOrEmpty(path));

var fileSystemVisitor = new FileSystemVisitor(path);

Console.WriteLine("Path contains the next folders: ");
foreach (var folder in fileSystemVisitor.GetFolders())
{
    Console.WriteLine(folder);
}
Console.WriteLine("Path contains the next files: ");
foreach (var file in fileSystemVisitor.GetFiles())
{
    Console.WriteLine(file);
}

var fileSystemVisitorWithCarrot = new FileSystemVisitor(path, OnlyElementsWithCarrot);
Console.WriteLine("Path contains the next folders that contains 'carrot': ");
foreach (var folder in fileSystemVisitorWithCarrot.GetFolders())
{
    Console.WriteLine(folder);
}
Console.WriteLine("Path contains the next files that contains 'carrot': ");
foreach (var file in fileSystemVisitorWithCarrot.GetFiles())
{
    Console.WriteLine(file);
}

IEnumerable<string> OnlyElementsWithCarrot(IEnumerable<string> files)
{
    return files.Where(f => f.Contains("carrot", StringComparison.InvariantCultureIgnoreCase));
}