using System;

namespace Factory
{
    public class Piechur : Wojownik
    {
        public Piechur(string nazwa) : base(nazwa) { }

        public override void OpiszSie()
        {
            Console.WriteLine($"Jestem piechurem o imieniu {Nazwa}. Walczę w zwarciu!");
        }
    }
}