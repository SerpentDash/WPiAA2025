using System;

namespace CodeSmells
{
    public class MessagingService
    {
        public void SendNotification(string recipient, string message)
        {
            Console.WriteLine($"Notification sent to {recipient}: {message}");
        }
    }
}
