using System;

namespace CodeSmells
{
    public class EventDetails
    {
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }

        public EventDetails(string eventName, DateTime eventDate, string location)
        {
            EventName = eventName;
            EventDate = eventDate;
            Location = location;
        }
    }

    public class EventManager
    {
        public void RegisterEvent(EventDetails details)
        {
            Console.WriteLine($"Event: {details.EventName}, Date: {details.EventDate}, Location: {details.Location}");
        }
    }
}
