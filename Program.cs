using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace WPiAA2025
{
    class Program
    {
        static void Main(string[] args)
        {
            var availableSolutions = Directory.GetDirectories("Solutions").Select(Path.GetFileName!).ToArray();

            if (args.Length == 0)
            {
                Console.WriteLine("Usage: dotnet run <solution>");
                ListSolutions(availableSolutions);
                return;
            }

            string inputSolution = args[0];
            var matchingSolution = availableSolutions.FirstOrDefault(p => string.Equals (p, inputSolution, StringComparison.OrdinalIgnoreCase));
            if (matchingSolution == null)
            {
                Console.WriteLine($"Solution '{inputSolution}' not found.");
                ListSolutions(availableSolutions);
                return;
            }

            string typeName = $"{matchingSolution}.Program";
            Type? type = Assembly.GetExecutingAssembly().GetType(typeName);
            MethodInfo? mainMethod = type?.GetMethod("Main", BindingFlags.Public | BindingFlags.Static, null, [typeof(string[])], null);

            try
            {
                mainMethod?.Invoke(null, [new string[0]]);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error running {matchingSolution}: {ex.Message}");
            }
        }

        static void ListSolutions(IEnumerable<string?> solutions)
        {
            Console.WriteLine("Available solutions:");
            foreach (var p in solutions)
                if (p != null) Console.WriteLine($"  - {p}");
        }
    }
}