using System;

namespace Factory
{
    // Base class for all warriors
    public abstract class Wojownik
    {
        public string Nazwa { get; set; }

        protected Wojownik(string nazwa)
        {
            Nazwa = nazwa;
        }

        public abstract void OpiszSie();
    }
}