using System;

namespace Builder
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