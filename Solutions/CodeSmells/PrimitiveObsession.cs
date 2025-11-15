using System;

namespace CodeSmells
{
    public class ProductDetails
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public ProductDetails(string name, string category, decimal price, int quantity)
        {
            Name = name;
            Category = category;
            Price = price;
            Quantity = quantity;
        }
    }

    public class ProductManager
    {
        public void RegisterProduct(ProductDetails details)
        {
            Console.WriteLine($"Product: {details.Name}, Category: {details.Category}, Price: {details.Price}, Quantity: {details.Quantity}");
        }
    }
}
