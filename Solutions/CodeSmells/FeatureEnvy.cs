using System;

namespace CodeSmells
{
    public class ShippingDetails
    {
        public string ShippingMethod { get; set; }
        public string Destination { get; set; }

        public decimal CalculateShippingCost(decimal amount)
        {
            if (ShippingMethod == "Air") {
                return amount * 0.2m;
            }

            if (ShippingMethod == "Sea") {
                return amount * 0.1m;
            }
            
            return amount * 0.15m;
        }
    }

    public class Order
    {
        public ShippingDetails ShippingDetails { get; set; }
        public decimal Amount { get; set; }

        public decimal GetShippingCost()
        {
            return ShippingDetails.CalculateShippingCost(Amount);
        }
    }
}
