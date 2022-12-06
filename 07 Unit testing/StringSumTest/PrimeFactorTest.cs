using PrimeFactor;
using FluentAssertions;
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
    [InlineData(2, new[] { 2 })]
    [InlineData(10, new[] { 2, 3, 5, 7 })]
    [InlineData(30, new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 })]
    [InlineData(100, new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 })]
    public void GetPrimeValues(int input, IEnumerable<int> primeFactorValues)
    {
        var response = _primeFactorSUT.GetPrimeValues(input);

        response.Should().BeEquivalentTo(primeFactorValues);
    }
}
