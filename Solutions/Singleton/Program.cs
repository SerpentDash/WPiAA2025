using System;

namespace Singleton
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Próba pobrania klucza po raz pierwszy:");
            string? key1 = Vault.Instance.GetKey();
            Console.WriteLine($"Klucz: {key1}");

            Console.WriteLine("\nPróba pobrania klucza po raz drugi:");
            string? key2 = Vault.Instance.GetKey();
            Console.WriteLine($"Klucz: {key2}");

            Console.WriteLine("\nPróba pobrania klucza po raz trzeci:");
            string? key3 = Vault.Instance.GetKey();
            Console.WriteLine($"Klucz: {key3}");
        }
    }
}
