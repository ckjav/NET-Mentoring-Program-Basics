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

        Console.WriteLine($"1");

        for (var i = 2; i <= input; ++i)
        {
            if (IsPrimeNumber(i))
            {
                Primes.Add(i);
                Console.WriteLine("prime");
                continue;
            }
            if (i % 2 != 0)
            {
                Console.WriteLine("composite");
            }
            else
            {
                Console.WriteLine($"{i}");
            }

        }

        return Primes;
    }
}