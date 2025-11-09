using System;

namespace Factory
{
    public class Konny : Wojownik
    {
        public Konny(string nazwa) : base(nazwa) { }

        public override void OpiszSie()
        {
            Console.WriteLine($"Jestem konnym o imieniu {Nazwa}. Jeżdżę na koniu!");
        }
    }
}