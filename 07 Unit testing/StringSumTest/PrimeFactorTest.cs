using PrimeFactor;
using Xunit;

namespace UnitTestingTest;

public class PrimeFactorTest
{
    private readonly IPrimeFactorGenerator _primeFactorSUT;

    public PrimeFactorTest()
    {

        _primeFactorSUT = new PrimeFactorGenerator();
    }

    [Theory]
    [InlineData(1, false)]
    [InlineData(10, true)]
    [InlineData(101, false)]
    public void IsValidRange_Scenarios(int input, bool isValid)
    {
        var response = _primeFactorSUT.IsValidRange(input);

        Assert.Equal(isValid, response);
    }

    [Theory]
    [InlineData(2, 1)]
    [InlineData(5, 3)]
    [InlineData(10, 5)]
    [InlineData(21, 11)]
    public void GetHigherValueToCompare_Scenarios(int input, int valueToCompare)
    {
        var response = _primeFactorSUT.GetHigherValueToCompare(input);

        Assert.Equal(valueToCompare, response);
    }
}
