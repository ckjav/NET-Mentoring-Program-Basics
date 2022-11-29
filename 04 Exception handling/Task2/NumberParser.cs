using System;
using System.Text.RegularExpressions;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            if (stringValue == null) throw new ArgumentNullException("stringValue");

            stringValue = stringValue.Trim();

            Regex regex = new Regex(@"^[+-]?\d+$");
            if (!regex.IsMatch(stringValue)) throw new FormatException("");
            
            int result = 0;
            int multiplyBy = 1;

            if (stringValue == "-2147483648") return int.MinValue;
            else if (stringValue == "2147483647") return int.MaxValue;
            else if (stringValue == "0" || stringValue == "-0" || stringValue == "+0") return 0;

            
            for (int index = stringValue.Length - 1; index >= 0; --index)
            {
                var numberAtPosition = (int)stringValue[index] - 48;

                if (numberAtPosition == -3) result *= -1;
                else if (numberAtPosition == -5) continue;
                else result += numberAtPosition * multiplyBy;

                multiplyBy *= 10;
            }

            if (!stringValue.Contains(Math.Abs(result).ToString()))  throw new OverflowException();

            return result;
        }
    }
}