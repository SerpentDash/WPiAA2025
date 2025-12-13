using System;

namespace Decorator
{
    public abstract class PaymentDecorator : IPayment
    {
        protected readonly IPayment _innerPayment;

        protected PaymentDecorator(IPayment innerPayment)
        {
            _innerPayment = innerPayment ?? throw new ArgumentNullException(nameof(innerPayment));
        }

        public virtual void Pay(decimal amount)
        {
            _innerPayment.Pay(amount);
        }
    }

    public class SmsNotificationDecorator : PaymentDecorator
    {
        public SmsNotificationDecorator(IPayment innerPayment) : base(innerPayment) { }

        public override void Pay(decimal amount)
        {
            base.Pay(amount);
            Console.WriteLine("[SMS] SMS notification sent: Payment successful.");
        }
    }

    public class LoyaltyPointsDecorator : PaymentDecorator
    {
        public LoyaltyPointsDecorator(IPayment innerPayment) : base(innerPayment) { }

        public override void Pay(decimal amount)
        {
            base.Pay(amount);
            var points = (int)Math.Floor(amount) / 10;
            Console.WriteLine($"[Loyalty] {points} loyalty points were added to the customer's account.");
        }
    }

    public class RedirectToHomeDecorator : PaymentDecorator
    {
        public RedirectToHomeDecorator(IPayment innerPayment) : base(innerPayment) { }

        public override void Pay(decimal amount)
        {
            base.Pay(amount);
            Console.WriteLine("[Redirect] Redirecting user to store homepage...");
        }
    }
}
