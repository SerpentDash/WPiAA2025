using System;

namespace Builder
{
    public abstract class WarriorBuilder
    {
        protected IWarrior? _warrior;

        public void ZapisDoArmii(string nazwa)
        {
            // Utworzenie obiektu odpowiedniego typu
            _warrior = CreateWarrior(nazwa);
        }

        public void PobierzBron()
        {
            // Pobranie broni - można dodać logikę specyficzną dla typu
            if (_warrior != null)
            {
                Console.WriteLine($"{_warrior.Nazwa} pobiera broń.");
            }
        }

        public void TreningWalki()
        {
            // Trening walki - można dodać logikę specyficzną dla typu
            if (_warrior != null)
            {
                Console.WriteLine($"{_warrior.Nazwa} przechodzi trening walki.");
            }
        }

        public IWarrior GetWarrior()
        {
            return _warrior ?? throw new InvalidOperationException("Warrior not built yet.");
        }

        protected abstract IWarrior CreateWarrior(string nazwa);
    }
}