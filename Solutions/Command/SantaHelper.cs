using System;

namespace Command
{
    public class SantaHelper
    {
        private readonly SantaClausFactory _factory;
        public SantaHelper(SantaClausFactory factory) => _factory = factory;
        public IProduct Send(ICommand command) => _factory.Handle(command);
    }
}