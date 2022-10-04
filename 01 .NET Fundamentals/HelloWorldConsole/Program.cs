using Logic;
using System;

namespace HelloWorldConsole
{

    public static class Program
    {
        static string username = string.Empty;

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                AskForUsername();
            } while (string.IsNullOrEmpty(username));

            Console.WriteLine(FormatterMessage.HelloWorld(username));
            Console.WriteLine("Type any key to quit");
            Console.ReadKey();
        }

        static void AskForUsername()
        {
            Console.WriteLine("Please type your username");
            username = Console.ReadLine();
        }
    }
}