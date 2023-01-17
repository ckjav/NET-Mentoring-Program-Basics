namespace BaseLibrary;

public abstract class Menu
{
    public static void DisplayOptionsForSerialization(ISerializerApp serializerApp, string filename)
    {
        Console.WriteLine("Type your option, please");
        Console.WriteLine($"1- Serialize (will create file {filename})");
        Console.WriteLine($"2- Deserialize (will read file {filename}");

        var key = Console.ReadKey();
        Console.WriteLine();

        switch (key.KeyChar)
        {
            case '1':
                serializerApp.Serialize();
                break;
            case '2':
                serializerApp.Deserialize();
                break;
            default:
                Console.WriteLine("You didn't pick a valid option, please run again.");
                break;
        }
    }

    public static void DisplayEntryMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Creating file with the next data:");
    }

    public static void DisplayFileCreationMessage(string filename)
    {
        Console.WriteLine($"File has been created, please look for '{filename}'.");
    }

    public static bool ValidateFilePath(string currentDirectory, string filename)
    {
        if (!File.Exists(Path.Combine(currentDirectory, filename)))
        {
            Console.WriteLine($"'{filename}' file doesn't exist, please, first execute serialization");
            return false;
        }

        return true;
    }

    public static void DisplayWritingFileErrorMessage()
    {
        Console.WriteLine("There was a problem writing file, please check permissions.");
    }

    public static void DisplayReadingFileErrorMessage(string filename)
    {
        Console.WriteLine($"There was a problem reading file {filename}, please check that file it's not corrupt and have permissions.");
    }

    public static void DisplayDepartmentInfo(Department? department)
    {
        if(department is null)
        {
            Console.WriteLine("Department hasn't value.");
            return;
        }

        Console.WriteLine($"Department name: {department.DepartmentName}");
        Console.WriteLine($"Department contains: {department.Employees?.Count()} employee(s)");

        var counter = 1;

        if (department.Employees == null || !department.Employees.Any())
        {
            Console.WriteLine("There are no employees");
        }
        else
        {
            foreach (var employee in department.Employees)
            {
                Console.WriteLine($"Employee {counter}:");
                Console.WriteLine($"Employee name: {employee.EmployeeName}");
            }
        }

        Console.WriteLine();
    }
}