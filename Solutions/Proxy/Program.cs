using System;

namespace Proxy
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var resources = new IFile[]
			{
				new PublicFile("ogloszenia.txt", "Wolny dostęp: dzisiejsze ogłoszenia..."),
				new ProtectedFile("tajne.txt", "Tajne dane: supersekretne!", "0000"),
				new PublicFile("darmowy.txt", "Darmowy plik z poradami..."),
				new ProtectedFile("dokument.txt", "Dane finansowe: ...", "1234")
			};

			var proxies = new FileProxy[resources.Length];
			for (int i = 0; i < resources.Length; i++)
				proxies[i] = new FileProxy(resources[i]);

			while (true)
			{
				Console.WriteLine("\nDostępne pliki:");
				for (int i = 0; i < proxies.Length; i++)
				{
					var protectedMark = resources[i] is IProtected ? "(chroniony)" : "";
					Console.WriteLine($" {i + 1}. {proxies[i].Name} {protectedMark}");
				}

				Console.WriteLine(" 0. Wyjscie");
				Console.Write("\nWybierz numer pliku: ");
				var input = Console.ReadLine();
				if (!int.TryParse(input, out int index))
				{
					Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.\n");
					continue;
				}

				if (index == 0)
					break;

				if (index < 1 || index > proxies.Length)
				{
					Console.WriteLine("Nie ma takiego pliku. Spróbuj ponownie.\n");
					continue;
				}

				var proxy = proxies[index - 1];
				string? password = null;

				if (resources[index - 1] is IProtected)
				{
					Console.Write("Wprowadź hasło: ");
					password = Console.ReadLine();
				}

				if (proxy.TryGetData(password ?? string.Empty, out string content))
				{
					Console.WriteLine("\n----------  ZAWARTOŚĆ PLIKU  -----------\n");
					Console.WriteLine(content);
					Console.WriteLine("\n----------------------------------------");
				}
				else
				{
                    Console.WriteLine("\n----------------  BŁĄD  ----------------\n");
					Console.WriteLine("Dostęp zabroniony — nieprawidłowe hasło!");
                    Console.WriteLine("\n----------------------------------------");
				}
			}

			Console.WriteLine("Koniec programu.");
		}
	}
}

