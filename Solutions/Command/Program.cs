using System;

namespace Command
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var helper = new SantaHelper(new SantaClausFactory());

            var produced = new IProduct[]
            {
                helper.Send(new MakeToyCommand("Car")),
                helper.Send(new MakeToyCommand("Doll")),
                helper.Send(new MakeToyCommand("Teddy Bear")),
                helper.Send(new MakeRodCommand())
            };

            Console.WriteLine("Produkcja Świętego Mikołaja:");
            foreach (var p in produced)
            {
                Console.WriteLine(" - " + p);
            }
        }
    }
}