using System;
using System.Threading.Tasks;

namespace Composite
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var rootMenu = BuildSampleMenu();

			Console.WriteLine("RESTAURANT MENU\n");

			if (args.Length > 0)
			{
				if (string.Equals(args[0], "full", StringComparison.OrdinalIgnoreCase))
				{
					Console.WriteLine("Full menu:");
					rootMenu.Print();
					return;
				}

				if (string.Equals(args[0], "list", StringComparison.OrdinalIgnoreCase))
				{
					Console.WriteLine("Top-level categories:");
					foreach (var child in rootMenu.Children)
						Console.WriteLine($" - {child.Name}");
					return;
				}

				if (string.Equals(args[0], "drill", StringComparison.OrdinalIgnoreCase) && args.Length > 1)
				{
					var key = args[1];
					var found = rootMenu.FindMenuByName(key);
					if (found == null)
						Console.WriteLine($"Category '{key}' not found.");
					else
						found.Print();
					return;
				}
			}
            

			Console.WriteLine("Type 'help' or 'h' for available commands.");

			while (true)
			{
				Console.Write("menu> ");
				var line = Console.ReadLine();
				if (string.IsNullOrEmpty(line))
					continue;

				var parts = line.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
				var cmd = parts[0].ToLowerInvariant();
				var arg = parts.Length > 1 ? parts[1] : null;

				switch (cmd)
				{
					case "quit":
					case "exit":
						return;
					case "h":
					case "help":
						PrintHelp();
						break;
					case "full":
						rootMenu.Print();
						break;
					case "list":
						Console.WriteLine("Top-level categories:");
						foreach (var child in rootMenu.Children)
						{
							Console.WriteLine($" - {child.Name}");
						}
						break;
					case "drill":
						if (string.IsNullOrWhiteSpace(arg))
						{
							Console.WriteLine("Usage: drill <category-name>");
							break;
						}
						var found = rootMenu.FindMenuByName(arg);
						if (found == null)
						{
							Console.WriteLine($"Category '{arg}' not found.");
						}
						else
						{
							found.Print();
						}
						break;
					default:
						Console.WriteLine($"Unknown command: {cmd}. Type 'help' to list commands.");
						break;
				}
			}
		}

		static Menu BuildSampleMenu()
		{
			var main = new Menu("Main Menu", "All available dishes and drinks");

			var starters = new Menu("Starters", "Small dishes to begin your meal");
			starters.Add(new MenuItem("Bruschetta", "Grilled bread with tomato and basil", 7.50m, true));
			starters.Add(new MenuItem("Soup of the Day", "Ask your waiter for today\'s soup", 6.00m));

			var mains = new Menu("Mains", "Main courses");
			var pasta = new Menu("Pasta", "Pasta-based main dishes");
			pasta.Add(new MenuItem("Spaghetti Bolognese", "House meat sauce", 18.50m));
			pasta.Add(new MenuItem("Penne Arrabiata", "Spicy tomato sauce", 16.00m, true));
			mains.Add(pasta);

			var meat = new Menu("Meat & Grill", "Steaks and grilled items");
			meat.Add(new MenuItem("Ribeye Steak", "250g ribeye with pepper sauce", 34.00m));
			meat.Add(new MenuItem("Grilled Chicken", "Chicken breast with herbs", 22.00m));
			mains.Add(meat);

			var desserts = new Menu("Desserts", "Sweet end of meal");
			desserts.Add(new MenuItem("Cheesecake", "Classic cheesecake", 9.50m));
			desserts.Add(new MenuItem("Chocolate Lava Cake", "Warm cake with molten center", 10.00m));

			var drinks = new Menu("Drinks", "Non-alcoholic and alcoholic beverages");
			drinks.Add(new MenuItem("Mineral Water", "Sparkling or still", 3.00m));
			var wines = new Menu("Wines", "Selection of red and white wines");
			wines.Add(new MenuItem("Red House Wine", "Glass (150ml)", 6.50m));
			wines.Add(new MenuItem("White House Wine", "Glass (150ml)", 6.50m));
			drinks.Add(wines);

			main.Add(starters);
			main.Add(mains);
			main.Add(desserts);
			main.Add(drinks);

			return main;
		}

		static void PrintHelp()
		{
			Console.WriteLine("Commands:");
			Console.WriteLine("  help|h        - show this help");
			Console.WriteLine("  list          - list top-level categories");
			Console.WriteLine("  full          - print the entire menu (structured)");
			Console.WriteLine("  drill <name>  - show a category and its sub-items by name (case-insensitive)");
			Console.WriteLine("  exit|quit     - exit the program");
		}
	}
}

