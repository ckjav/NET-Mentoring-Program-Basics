namespace PrimeFactor;

public interface IPrimeFactorGenerator
{
    bool IsValidRange(int input);

    int IncreaseFactor(int input);

    IEnumerable<int> GetPrimeValues(int input);
}
