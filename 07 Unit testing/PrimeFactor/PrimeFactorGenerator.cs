namespace PrimeFactor;

public class PrimeFactorGenerator : IPrimeFactorGenerator
{
    List<int> Primes { get; set; }

    public PrimeFactorGenerator()
    {
    }

    public bool IsValidRange(int input)
    {
        return input > 1 && input <= 100;
    }

    public int GetHigherValueToCompare(int input)
    {
        var isOdd = input % 2;

        return isOdd == 1 ? (input / 2) + 1 : input / 2;
    }

    public IEnumerable<int> GetPrimeValues(int input)
    {
        if (!IsValidRange(input)) throw new ArgumentOutOfRangeException("Start value must be greater or equal than 2 and less or equal than 100.");

        return Primes;
    }
}