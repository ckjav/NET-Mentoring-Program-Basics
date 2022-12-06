namespace PrimeFactor;

public interface IPrimeFactorGenerator
{
    bool IsValidRange(int input);

    int GetHigherValueToCompare(int input);

    IEnumerable<int> GetPrimeValues(int input);
}
