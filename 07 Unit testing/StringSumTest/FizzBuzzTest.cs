using FizzBuzz;
using FluentAssertions;

namespace UnitTestingTest;

public class FizzBuzzTest
{
    private readonly FizzBuzzGenerator _fizzBuzzGenerator;

    public FizzBuzzTest()
    {
        _fizzBuzzGenerator = new FizzBuzzGenerator();
    }

    [Theory]
    [InlineData(3, "Fizz")]
    [InlineData(5, "")]
    [InlineData(12, "Fizz")]
    [InlineData(29, "")]
    public void IsMultipleByThree_Scenarios(int input, string expectedString)
    {
        var response = _fizzBuzzGenerator.IsMultipleByThree(input);

        response.Should().Be(expectedString);
    }

    [Theory]
    [InlineData(3, "")]
    [InlineData(5, "Buzz")]
    [InlineData(12, "")]
    [InlineData(20, "Buzz")]
    public void IsMultipleByFive_Scenarios(int input, string expectedString)
    {
        var response = _fizzBuzzGenerator.IsMultipleByFive(input);

        response.Should().Be(expectedString);
    }

    [Theory]
    [InlineData(3, "Fizz")]
    [InlineData(5, "Buzz")]
    [InlineData(7, "7")]
    [InlineData(10, "Buzz")]
    [InlineData(12, "Fizz")]
    [InlineData(13, "13")]
    [InlineData(15, "FizzBuzz")]
    [InlineData(20, "Buzz")]
    [InlineData(30, "FizzBuzz")]
    public void CheckFactors_Scenarios(int input, string expectedString)
    {
        var response = _fizzBuzzGenerator.CheckFactors(input);

        response.Should().Be(expectedString);
    }
}
