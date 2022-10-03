using Logic;
using System;

namespace HelloWorldConsole
{

    public static class Program
    {
        static string username = string.Empty;

        static void Main(string[] args)
        {
            bool isValidUsername;

            do
            {
                Console.Clear();
                isValidUsername = AskForUsername();
            } while (!isValidUsername);

            Console.WriteLine(FormatterMessage.HelloWorld(username));
            Console.WriteLine("Type any key to quit");
            Console.ReadKey();
        }

        static bool AskForUsername()
        {
            Console.WriteLine("Please type your username");
            username = Console.ReadLine();
            return !string.IsNullOrEmpty(username);
        }
    }
}