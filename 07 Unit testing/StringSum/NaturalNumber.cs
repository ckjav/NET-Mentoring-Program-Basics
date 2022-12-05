namespace StringSum;

public class NaturalNumber : INaturalNumber
{
    public int Parse(string input)
    {
        if (string.IsNullOrEmpty(input)) return 0;

        return int.Parse(input);
    }
}
