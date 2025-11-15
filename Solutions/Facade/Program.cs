using System;
using System.Threading.Tasks;

namespace Facade
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            if (args.Length == 0 || string.IsNullOrWhiteSpace(args[0]))
            {
                Console.WriteLine("Usage: dotnet run Facade <OPENWEATHERMAP_API_KEY>");
                return;
            }

            string apiKey = args[0];

            IWeatherFacade facade = new WeatherFacade(apiKey);

            var cities = new[] { "Warsaw", "London", "New York", "Tokyo", "Berlin" };

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Choose city by number (or press Enter to exit):");
                for (int i = 0; i < cities.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {cities[i]}");
                }
                Console.Write("> ");

                var input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                    break;

                if (!int.TryParse(input, out int idx) || idx < 1 || idx > cities.Length)
                {
                    Console.WriteLine($"Invalid selection: please enter a number between 1 and {cities.Length}.");
                    continue;
                }

                string selectedCity = cities[idx - 1];
                var desc = await facade.GetShortWeatherDescriptionAsync(selectedCity);
                if (desc == null)
                {
                    Console.WriteLine($"Could not obtain weather data for '{selectedCity}'. Check API key or network.");
                }
                else
                {
                    Console.WriteLine(desc);
                }
            }
        }
    }
}
