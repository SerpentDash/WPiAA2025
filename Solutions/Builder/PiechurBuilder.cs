using System;

namespace Builder
{
    public class PiechurBuilder : WarriorBuilder
    {
        protected override IWarrior CreateWarrior(string nazwa)
        {
            return new Piechur(nazwa);
        }
    }
}