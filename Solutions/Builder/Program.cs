using System;

namespace Builder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Garnizon garnizon = new Garnizon();

            // Dodaj 2 piechurów
            for (int i = 1; i <= 2; i++)
            {
                WarriorBuilder builder = new PiechurBuilder();
                garnizon.SzkolWojownika(builder, $"Piechur{i}");
            }

            // Dodaj 2 konnych
            for (int i = 1; i <= 2; i++)
            {
                WarriorBuilder builder = new KonnyBuilder();
                garnizon.SzkolWojownika(builder, $"Konny{i}");
            }

            // Dodaj 2 strzelców
            for (int i = 1; i <= 2; i++)
            {
                WarriorBuilder builder = new StrzelecBuilder();
                garnizon.SzkolWojownika(builder, $"Strzelec{i}");
            }

            Console.WriteLine("Wojownicy w garnizonie:");
            foreach (var wojownik in garnizon.Wojownicy)
            {
                wojownik.OpiszSie();
            }
        }
    }
}