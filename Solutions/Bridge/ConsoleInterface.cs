using System;

namespace Bridge
{
    public class ConsoleInterface : Interface
    {
        public ConsoleInterface(ISystem system) : base(system)
        {
        }

        public override void DisplayMenu()
        {
            Console.WriteLine("[Console Interface] List:");
            foreach (var app in System.GetInstalledPrograms())
            {
                Console.WriteLine(" - " + app);
            }
        }
    }
}
