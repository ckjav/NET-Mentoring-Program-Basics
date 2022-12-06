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
    public void IsValidRange(int input, bool isValid)
    {
        var response = _primeFactorSUT.IsValidRange(input);

        Assert.Equal(isValid, response);
    }
}
