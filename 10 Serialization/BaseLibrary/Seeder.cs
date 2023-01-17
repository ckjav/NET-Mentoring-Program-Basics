using AutoFixture;

namespace BaseLibrary;

public static class Seeder
{
    public static Department GetDepartment()
    {
        var fixture = new Fixture();

        return fixture.Build<Department>().Create();
    }
}
