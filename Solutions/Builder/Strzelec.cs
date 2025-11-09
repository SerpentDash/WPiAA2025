using System;

namespace Builder
{
    public class Strzelec : Wojownik
    {
        public Strzelec(string nazwa) : base(nazwa) { }

        public override void OpiszSie()
        {
            Console.WriteLine($"Jestem strzelcem o imieniu {Nazwa}. Strzelam z łuku!");
        }
    }
}