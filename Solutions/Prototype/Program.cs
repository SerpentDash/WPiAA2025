// !!! dotnet add package Newtonsoft.Json

namespace Prototype
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Stwórz nowego orka
            Ork originalOrk = new Ork("Grishnak", 10, 100);
            Console.WriteLine("Oryginalny ork:");
            Console.WriteLine(originalOrk);
            Console.WriteLine();

            // W pętli stwórz kilka klonów za pomocą serializacji i deserializacji
            List<Ork> orkClones = new List<Ork>();
            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                Ork clone = originalOrk.Clone();

                // Zmień losowo parametr siły
                clone.Strength = random.Next(5, 30);
                clone.Name = $"{originalOrk.Name} Clone {i + 1}";

                orkClones.Add(clone);
            }

            // Wyświetl klony
            Console.WriteLine("Klonowane orki:");
            foreach (var ork in orkClones)
            {
                Console.WriteLine(ork);
            }
        }
    }
}
