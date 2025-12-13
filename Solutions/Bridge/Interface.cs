using System;

namespace Bridge
{
    public abstract class Interface
    {
        protected ISystem System { get; }

        protected Interface(ISystem system)
        {
            System = system ?? throw new ArgumentNullException(nameof(system));
        }

        public abstract void DisplayMenu();
    }
}
