namespace PrimeFactor;

public class PrimeFactorGenerator : IPrimeFactorGenerator
{
    List<int> Primes { get; set; }

    public PrimeFactorGenerator()
    {
        Primes = new List<int>();
    }

    public bool IsValidRange(int input)
    {
        return input > 0 && input <= 100;
    }

    public int IncreaseFactor(int input)
    {
        switch (input)
        {
            case 2: return 1;
            default: return 2;
        }
    }

    private bool IsPrimeNumber(int input)
    {
        foreach (var prime in Primes)
        {
            if (input % prime == 0)
            {
                return false;
            }
        }

        return true;
    }

    public IEnumerable<int> GetPrimeValues(int input)
    {
        if (!IsValidRange(input)) throw new ArgumentOutOfRangeException("Start value must be greater or equal than 2 and less or equal than 100.");

        for (var i = 2; i <= input;)
        {
            if (IsPrimeNumber(i))
            {
                Primes.Add(i);
            }

            i += IncreaseFactor(i);
        }

        return Primes;
    }
}