using System;

namespace Factory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Garnizon garnizon = new Garnizon();

            Wojownik[] wojownicy = new Wojownik[10];

            // 3 Piechur
            for (int i = 0; i < 3; i++)
            {
                wojownicy[i] = garnizon.WyszkolWojownika("piechur", $"Piechur{i + 1}");
            }

            // 3 Konny
            for (int i = 0; i < 3; i++)
            {
                wojownicy[i + 3] = garnizon.WyszkolWojownika("konny", $"Konny{i + 1}");
            }

            // 4 Strzelec
            for (int i = 0; i < 4; i++)
            {
                wojownicy[i + 6] = garnizon.WyszkolWojownika("strzelec", $"Strzelec{i + 1}");
            }

            Console.WriteLine("Wojownicy w garnizonie:");
            foreach (var wojownik in wojownicy)
            {
                wojownik.OpiszSie();
            }
        }
    }
}
