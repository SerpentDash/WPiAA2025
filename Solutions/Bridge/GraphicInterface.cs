using System;

namespace Bridge
{
    public class GraphicInterface : Interface
    {
        public GraphicInterface(ISystem system) : base(system)
        {
        }

        public override void DisplayMenu()
        {
            Console.WriteLine("[Graphic Interface] (Menu window)\n");
            Console.WriteLine("Installed Applications:");
            foreach (var app in System.GetInstalledPrograms())
            {
                Console.WriteLine($"[icon] {app}");
            }
            Console.WriteLine("==============================================");
        }
    }
}
