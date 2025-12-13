using System;

namespace Decorator
{
    public class Shop
    {
        public void ProcessPayment(PaymentMethod method, decimal amount)
        {
            Console.WriteLine($"\nProcessing {method} payment for {amount:C}...");
            IPayment paymentProcessor;

            switch (method)
            {
                case PaymentMethod.Cash:
                    paymentProcessor = new CashPayment();
                    break;
                case PaymentMethod.Mobile:
                    paymentProcessor = new MobilePayment();
                    break;
                case PaymentMethod.Card:
                    paymentProcessor = new SmsNotificationDecorator(
                                            new LoyaltyPointsDecorator(
                                                new RedirectToHomeDecorator(
                                                    new CardPayment())));
                    break;
                default:
                    throw new NotSupportedException("Unknown payment method");
            }

            paymentProcessor.Pay(amount);
        }
    }
}
