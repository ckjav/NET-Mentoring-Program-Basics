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

        Assert.Equal(0L, response);
    }

    [Fact]
    public void IsANumber_WhenReceivesStringAndNumber_ShouldReturnZero()
    {
        var input = "a1";

        var response = _naturalNumberSUT.Parse(input);

        Assert.Equal(0L, response);
    }

    [Fact]
    public void IsANumber_WhenReceivesNegativeNumber_ShouldReturnZero()
    {
        var input = "-1";

        var response = _naturalNumberSUT.Parse(input);

        Assert.Equal(0L, response);
    }

    [Fact]
    public void IsANumber_WhenReceivesNumberWithDecimals_ShouldReturnZero()
    {
        var input = "11.32";

        var response = _naturalNumberSUT.Parse(input);

        Assert.Equal(0L, response);
    }
}