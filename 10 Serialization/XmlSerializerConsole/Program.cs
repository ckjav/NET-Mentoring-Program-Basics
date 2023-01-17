using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace XmlSerializerConsole;

public static class Program
{
    static readonly string filename = "department.xml";

    public static void Main()
    {
        Serialize();
    }

    private static void Serialize()
    {
        var department = new Department
        {
            DepartmentName = "Account"
        };

        var objEmployeeA = new Employee
        {
            EmployeeName = "First employee"
        };

        var objEmployeeZ = new Employee
        {
            EmployeeName = "Last employee"
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
            XmlSerializer formatter = new(typeof(Department));
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
                Console.WriteLine($"Employee name: {employee.EmployeeName}");
            }
        }

        Console.WriteLine();
    }
}