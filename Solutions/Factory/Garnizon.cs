using System;

namespace Factory
{
    public class Garnizon
    {
        public Wojownik WyszkolWojownika(string profesja, string nazwa)
        {
            switch (profesja.ToLower())
            {
                case "piechur":
                    return new Piechur(nazwa);
                case "strzelec":
                    return new Strzelec(nazwa);
                case "konny":
                    return new Konny(nazwa);
                default:
                    throw new ArgumentException($"Nieznana profesja: {profesja}");
            }
        }
    }
}