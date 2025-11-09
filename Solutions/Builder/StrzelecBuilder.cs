using System;

namespace Builder
{
    public class StrzelecBuilder : WarriorBuilder
    {
        protected override IWarrior CreateWarrior(string nazwa)
        {
            return new Strzelec(nazwa);
        }
    }
}