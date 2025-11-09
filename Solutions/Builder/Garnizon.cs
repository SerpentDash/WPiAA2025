using System;
using System.Collections.Generic;

namespace Builder
{
    public class Garnizon
    {
        public List<IWarrior> Wojownicy { get; private set; } = new List<IWarrior>();

        public void SzkolWojownika(WarriorBuilder builder, string nazwa)
        {
            builder.ZapisDoArmii(nazwa);
            builder.PobierzBron();
            builder.TreningWalki();
            IWarrior warrior = builder.GetWarrior();
            Wojownicy.Add(warrior);
        }
    }
}