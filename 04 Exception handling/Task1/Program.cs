using System;
using static System.Console;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ReadStringLines();
        }

        private static void ReadStringLines()
        {
            while (true)
            {
                WriteLine("Hello! Please type anything and press enter.");
                var input = ReadLine();

                try
                {
                    if (string.IsNullOrEmpty(input)) throw new ArgumentException("");

                    WriteLine($"First char of your previous input was '{input[0]}'");
                }
                catch (ArgumentException)
                {
                    WriteLine("Previous input was an empty string.");
                }
                catch (Exception ex)
                {
                    WriteLine("Unexpected exception, details: " + ex.Message);
                }
                finally
                {
                    WriteLine("Press any key to continue and repeat input.\n");
                }
            }
        }
    }
}