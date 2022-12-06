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
    public void Parse_WhenReceivesEmptyString_ShouldReturnZero()
    {
        var input = "";

        var response = _naturalNumberSUT.Parse(input);

        Assert.Equal(0L, response);
    }

    [Fact]
    public void Parse_WhenReceivesStringAndNumber_ShouldReturnZero()
    {
        var input = "a1";

        var response = _naturalNumberSUT.Parse(input);

        Assert.Equal(0L, response);
    }

    [Fact]
    public void Parse_WhenReceivesNegativeNumber_ShouldReturnZero()
    {
        var input = "-1";

        var response = _naturalNumberSUT.Parse(input);

        Assert.Equal(0L, response);
    }

    [Fact]
    public void Parse_WhenReceivesNumberWithDecimals_ShouldReturnZero()
    {
        var input = "11.32";

        var response = _naturalNumberSUT.Parse(input);

        Assert.Equal(0L, response);
    }

    [Fact]
    public void Parse_WhenReceivesNumber_ShoulReturnNumber()
    {
        var input = "2812";

        var response = _naturalNumberSUT.Parse(input);

        Assert.Equal(2812, response);
    }
}