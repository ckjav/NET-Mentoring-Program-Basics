namespace PrimeFactor;

public class PrimeFactorGenerator: IPrimeFactorGenerator
{
    List<int> Primes { get; set; }

    public PrimeFactorGenerator()
    {
    }

    public bool IsValidRange(int input)
    {
        return input > 1 && input <= 100;
    }
}