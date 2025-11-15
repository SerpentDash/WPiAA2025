using System;

namespace CodeSmells
{
    public class Transaction
    {
        public bool VerifyDetails()
        {
            return true;
        }
    }

    public class PaymentProcessor
    {
        public void PerformTransaction(Transaction transaction)
        {
            if (!ValidateTransaction(transaction)) return;

            ProcessPayment(transaction);
            UpdateAccount(transaction);
            CreateReceipt(transaction);
        }

        private bool ValidateTransaction(Transaction transaction)
        {
            return transaction.VerifyDetails();
        }

        private void ProcessPayment(Transaction transaction)
        {
            Console.WriteLine("Processing payment...");
        }

        private void UpdateAccount(Transaction transaction)
        {
            Console.WriteLine("Updating account...");
        }

        private void CreateReceipt(Transaction transaction)
        {
            Console.WriteLine("Creating receipt...");
        }
    }
}
