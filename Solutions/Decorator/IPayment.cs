using System;

namespace Decorator
{
    public enum PaymentMethod
    {
        Cash,
        Card,
        Mobile
    }

    public interface IPayment
    {
        void Pay(decimal amount);
    }
}
