namespace BinarySerializerConsole;

[Serializable]
public class Department
{
    public string DepartmentName { get; set; }

    public IEnumerable<Employee> Employees { get; set; }
}