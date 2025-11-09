using System;

namespace Builder
{
    public abstract class Wojownik : IWarrior
    {
        public string Nazwa { get; set; }

        protected Wojownik(string nazwa)
        {
            Nazwa = nazwa;
        }

        public abstract void OpiszSie();
    }
}