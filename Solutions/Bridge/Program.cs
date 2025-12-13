using System;
using Bridge;

namespace Bridge
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			var linux = new LinuxSystem();
			var consoleUi = new ConsoleInterface(linux);
			Console.WriteLine("=== Linux (CLI) ===");
			consoleUi.DisplayMenu();
			Console.WriteLine();

			var linuxGraphic = new GraphicInterface(linux);
			Console.WriteLine("=== Linux (GUI) ===");
			linuxGraphic.DisplayMenu();
			Console.WriteLine();

			var windows = new WindowsSystem();
			var windowsGraphic = new GraphicInterface(windows);
			Console.WriteLine("=== Windows (GUI) ===");
			windowsGraphic.DisplayMenu();
			Console.WriteLine();

			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}
	}
}

