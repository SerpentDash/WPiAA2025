using System;

namespace Command
{
    public class SantaClausFactory
    {
        public IProduct Handle(ICommand command)
        {
            switch (command)
            {
                case MakeToyCommand mt:
                    return new Toy(mt.ToyName);
                case MakeRodCommand:
                    return new Rod();
                default:
                    throw new ArgumentException("Unknown command", nameof(command));
            }
        }
    }
}
