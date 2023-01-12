using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace BinarySerializerConsole;

public static class Program
{
    static readonly string filename = "department.bin";

    public static void Main(string[] args)
    {
        Console.WriteLine("Type your option, please");
        Console.WriteLine($"1- Serialize (will create file {filename})");
        Console.WriteLine($"2- Deserialize (will read file {filename}");

        var key = Console.ReadKey();
        Console.WriteLine();

        switch (key.KeyChar)
        {
            case '1':
                Serialize();
                break;
            case '2':
                Deserialize();
                break;
            default:
                Console.WriteLine("You didn't pick a valid option, please run again.");
                break;
        }
    }

    private static void Serialize()
    {
        var department = new Department
        {
            DepartmentName = "Account"
        };

        var objEmployeeA = new Employee
        {
            EmpoyeeName = "First employee"
        };

        var objEmployeeZ = new Employee
        {
            EmpoyeeName = "Last employee"
        };

        department.Employees = new List<Employee>
        {
            objEmployeeA,
            objEmployeeZ
        };

        Console.WriteLine();
        Console.WriteLine("Creating file with the next data:");
        DisplayDepartmentInfo(department);

        try
        {
            IFormatter formatter = new BinaryFormatter();
            using Stream stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, department);
            stream.Close();
            Console.WriteLine($"File has been created, please look for '{filename}'.");
        }
        catch
        {
            Console.WriteLine("There was a problem writing file, please check permissions.");
            throw;
        }
    }

    private static void Deserialize()
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        if (!File.Exists(Path.Combine(currentDirectory, filename)))
        {
            Console.WriteLine($"'{filename}' file doesn't exist, please, first execute serialization");
            return;
        }

        Console.WriteLine($"Deserializing file {filename}");

        try
        {
            IFormatter formatter = new BinaryFormatter();
            using Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None);
            var department = (Department)formatter.Deserialize(stream);
            stream.Close();

            Console.WriteLine("File had been deserialized.");
            DisplayDepartmentInfo(department);
        }
        catch
        {
            Console.WriteLine($"There was a problem reading file {filename}, please check that file it's not corrupt and have permissions.");
            throw;
        }
    }

    private static void DisplayDepartmentInfo(Department department)
    {
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
                Console.WriteLine($"Employee name: {employee.EmpoyeeName}");
            }
        }

        Console.WriteLine();
    }
}
