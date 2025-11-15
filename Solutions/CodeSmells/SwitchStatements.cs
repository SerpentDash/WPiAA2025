using System;

namespace CodeSmells
{
    public interface IPaymentFeeStrategy
    {
        decimal DeterminePaymentFee(decimal amount);
    }

    public class CreditCardFeeStrategy : IPaymentFeeStrategy
    {
        public decimal DeterminePaymentFee(decimal amount) => amount * 0.02m;
    }

    public class PayPalFeeStrategy : IPaymentFeeStrategy
    {
        public decimal DeterminePaymentFee(decimal amount) => amount * 0.03m;
    }

    public class BankTransferFeeStrategy : IPaymentFeeStrategy
    {
        public decimal DeterminePaymentFee(decimal amount) => amount * 0.01m;
    }

    public class Payment
    {
        private readonly IPaymentFeeStrategy _strategy;

        public Payment(IPaymentFeeStrategy strategy)
        {
            _strategy = strategy;
        }

        public decimal DeterminePaymentFee(decimal amount)
        {
            return _strategy.DeterminePaymentFee(amount);
        }
    }
}
