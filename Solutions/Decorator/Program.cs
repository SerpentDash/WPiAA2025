using System;

namespace Decorator
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var shop = new Shop();

			shop.ProcessPayment(PaymentMethod.Cash, 12.99m);
			shop.ProcessPayment(PaymentMethod.Mobile, 25.50m);
			shop.ProcessPayment(PaymentMethod.Card, 100.00m);
		}
	}
}
