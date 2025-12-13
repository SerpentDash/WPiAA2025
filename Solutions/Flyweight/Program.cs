using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Flyweight
{
	class Program
	{
		public static void Main(string[] args)
		{
			var candidates = new[]
			{
				Path.Combine(Directory.GetCurrentDirectory(), "Solutions", "Flyweight", "Textures"),
				Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, "Solutions", "Flyweight", "Textures"),
				Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Solutions", "Flyweight", "Textures"),
				Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Textures")
			};
			var basePath = candidates.FirstOrDefault(Directory.Exists) ?? candidates[0];
			//Console.WriteLine($"Textures path: {Path.GetFileName(basePath)} (resolved from: {basePath})");

			var grass = Path.Combine(basePath, "grass.txt");
			var hero = Path.Combine(basePath, "hero.txt");
			var rock = Path.Combine(basePath, "rock.txt");
			var textureFactory = new TextureFactory();

			var objects = new List<GameObject>
			{
				new GameObject("Tree1", grass),
				new GameObject("Tree2", grass),
				new GameObject("Hero", hero),
				new GameObject("Stone1", rock),
				new GameObject("Stone2", rock),
				new GameObject("Villager", hero),
			};

			Console.WriteLine("Initializing objects (textures will be loaded lazily via the factory)...\n");
			foreach (var o in objects)
			{
				o.Initialize(textureFactory);
			}

			Console.WriteLine($"\nFactory cache contains {textureFactory.CacheCount} unique textures.\n");

			Console.WriteLine("Rendering scene:\n");
			foreach (var o in objects)
			{
				o.Draw();
			}

			Console.WriteLine();
			Console.WriteLine("Demonstration: Show shared instances by comparing references:");
			Console.WriteLine("Tree1 & Tree2: " + ReferenceEquals(objects[0], objects[1]));
			Console.WriteLine("Tree1 texture == Tree2 texture: " + ReferenceEquals(textureFactory.GetTexture(grass), textureFactory.GetTexture(grass)));
			Console.WriteLine("Hero & Villager textures reference equal: " + ReferenceEquals(textureFactory.GetTexture(hero), textureFactory.GetTexture(hero)));
		}
	}
}
