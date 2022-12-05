using StringSum;

namespace StringSumTest;

public class NaturalNumberTest
{
    private readonly INaturalNumber _naturalNumberSUT;

    public NaturalNumberTest()
    {
        _naturalNumberSUT = new NaturalNumber();
    }

    [Fact]
    public void IsANumber_WhenReceivesEmptyString_ShouldReturnZero()
    {
        var input = "";

        var response = _naturalNumberSUT.Parse(input);

        Assert.Equal(0, response);
    }
}