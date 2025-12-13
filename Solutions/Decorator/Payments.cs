using System;

namespace Decorator
{
    public class CashPayment : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"[Cash] Paid {amount:C} with cash.");
        }
    }

    public class MobilePayment : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"[Mobile] Paid {amount:C} via mobile app.");
        }
    }

    public class CardPayment : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"[Card] Charged card for {amount:C}. (Simulated)");
        }
    }
}
