using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Strategy;

namespace Strategy
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Read API keys from secrets file
            var secretsPath = Path.Combine("Solutions", "Strategy", "secrets.json");

            if (!File.Exists(secretsPath))
            {
                Console.WriteLine("Missing secrets file: Solutions/Strategy/secrets.json");
                Console.WriteLine(@"{");
                Console.WriteLine("  \"PEXELS_API_KEY\": \"your_pexels_key_here\",");
                Console.WriteLine("  \"PIXABAY_API_KEY\": \"your_pixabay_key_here\"");
                Console.WriteLine(@"}");
                return;
            }

            string? pexelsKey = null;
            string? pixabayKey = null;
            try
            {
                var json = File.ReadAllText(secretsPath);
                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;
                if (root.TryGetProperty("PEXELS_API_KEY", out var p1)) pexelsKey = p1.GetString();
                if (root.TryGetProperty("PIXABAY_API_KEY", out var p2)) pixabayKey = p2.GetString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to read or parse secrets file: {ex.Message}");
                return;
            }

            if (string.IsNullOrWhiteSpace(pexelsKey) && string.IsNullOrWhiteSpace(pixabayKey))
            {
                Console.WriteLine("Secrets file contains no API keys. Fill at least one of PEXELS_API_KEY or PIXABAY_API_KEY in Solutions/Strategy/secrets.json.");
                return;
            }

            string providerInput = args.Length >= 1 ? args[0].Trim() : string.Empty;
            string category = args.Length >= 2 ? args[1] : string.Empty;

            static bool HasKey(string providerInput, string? pexelsKey, string? pixabayKey) =>
                providerInput == "1" ? !string.IsNullOrWhiteSpace(pexelsKey) : !string.IsNullOrWhiteSpace(pixabayKey);

            // Prompt until a valid provider (1/2) with a configured key is selected
            while (true)
            {
                if (string.IsNullOrWhiteSpace(providerInput))
                {
                    Console.WriteLine("Select provider:");
                    Console.WriteLine("  1) Pexels");
                    Console.WriteLine("  2) Pixabay");
                    Console.Write("Enter provider to use (1 or 2): ");
                    providerInput = (Console.ReadLine() ?? string.Empty).Trim();
                }

                if (providerInput != "1" && providerInput != "2")
                {
                    Console.WriteLine("Invalid selection. Please enter 1 or 2.");
                    providerInput = string.Empty;
                    continue;
                }

                if (!HasKey(providerInput, pexelsKey, pixabayKey))
                {
                    Console.WriteLine(providerInput == "1" ? "Pexels API key not configured." : "Pixabay API key not configured.");
                    Console.WriteLine("Edit Solutions/Strategy/secrets.json and add the key, or choose the other provider.\n");
                    providerInput = string.Empty;
                    continue;
                }

                break;
            }

            var provider = providerInput == "1" ? "pexels" : "pixabay";

            // Prompt for category
            while (string.IsNullOrWhiteSpace(category))
            {
                Console.Write("Enter category to search for: ");
                category = (Console.ReadLine() ?? string.Empty).Trim();
                if (string.IsNullOrWhiteSpace(category)) Console.WriteLine("Category cannot be empty.");
            }

            IImageSearchStrategy strategy = provider == "pexels"
                ? new PexelsSearchStrategy(new HttpClient(), pexelsKey!)
                : new PixabaySearchStrategy(new HttpClient(), pixabayKey!);

            List<ImageResult> results;
            try
            {
                results = (await strategy.SearchAsync(category, perPage: 10)).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Search failed: {ex.Message}");
                return;
            }

            Console.WriteLine($"Found {results.Count} results from {provider} for '{category}':\n");
            int idx = 1;
            foreach (var r in results)
            {
                Console.WriteLine($"{idx++}. [{r.Source}] {r.Photographer} - {r.ThumbnailUrl} - {r.FullUrl}");
            }
        }
    }
}
