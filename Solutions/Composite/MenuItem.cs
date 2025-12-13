using System;
namespace Composite
{
    public class MenuItem : MenuComponent
    {
        public decimal Price { get; }
        public bool IsVegetarian { get; }

        public MenuItem(string name, string? description, decimal price, bool isVegetarian = false)
            : base(name, description)
        {
            Price = price;
            IsVegetarian = isVegetarian;
        }

        public override void Print(int indent = 0)
        {
            var ind = new string(' ', indent * 2);
            var vegSuffix = IsVegetarian ? " (V)" : string.Empty;
            Console.WriteLine($"{ind}- {Name}{vegSuffix} : {Price:C} - {Description}");
        }
    }
}
