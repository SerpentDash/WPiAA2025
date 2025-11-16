using System;

namespace Adapter
{
    internal class Teenager : Client
    {
        public Teenager(string name, int age) : base(name, age)
        {
        }

        public override void letsParty()
        {
            Console.WriteLine("Poproszę redbulla");
        }
    }
}
