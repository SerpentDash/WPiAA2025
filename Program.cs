using System;
using Factory;
using Singleton;

namespace WPiAA2025
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: dotnet run <pattern>");
                Console.WriteLine("Available patterns: factory, singleton");
                return;
            }

            string pattern = args[0].ToLower();

            if (pattern == "factory")
            {
                Factory.Program.Main(new string[0]);
            }
            else if (pattern == "singleton")
            {
                Singleton.Program.Main(new string[0]);
            }
            else
            {
                Console.WriteLine("Invalid pattern. Available: factory, singleton");
            }
        }
    }
}