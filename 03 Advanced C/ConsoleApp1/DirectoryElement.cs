namespace FileSystemVisitor;

public class DirectoryElement
{
    public DirectoryElementType ElementType;

    public string Name;

    public int DepthLevel;
}

public enum DirectoryElementType
{
    Directory,
    File
}
