using System;

namespace Builder
{
    public class KonnyBuilder : WarriorBuilder
    {
        protected override IWarrior CreateWarrior(string nazwa)
        {
            return new Konny(nazwa);
        }
    }
}