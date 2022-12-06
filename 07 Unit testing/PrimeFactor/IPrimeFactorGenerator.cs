namespace PrimeFactor;

public interface IPrimeFactorGenerator
{
    bool IsValidRange(int input);

    IEnumerable<int> GetPrimeValues(int input);
}
