namespace FizzBuzz;

public class FizzBuzzGenerator
{
    public void Calculate()
    {
        for(var i = 1; i<= 100; ++i)
        {
            Console.WriteLine(CheckFactors(i));
        }
    }

    public string IsMultipleByThree(int input)
    {
        return input % 3 == 0 ? "Fizz" : string.Empty;
    }

    public string IsMultipleByFive(int input)
    {
        return input % 5 == 0 ? "Buzz" : string.Empty;
    }

    public string CheckFactors(int input)
    {
        var response = IsMultipleByThree(input) + IsMultipleByFive(input);
        return string.IsNullOrEmpty(response) ? input.ToString() : response;
    }
}