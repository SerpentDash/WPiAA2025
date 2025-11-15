using System;

namespace CodeSmells
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        public string GetFormattedPrice()
        {
            return Price.ToString("C");
        }

        public bool IsInStock()
        {
            return StockQuantity > 0;
        }
    }
}
