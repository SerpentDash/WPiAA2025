using System;

namespace CodeSmells
{
    public interface IEmployee
    {
        void Work();
        void AttendMeeting();
    }

    public class Employee : IEmployee
    {
        public string Name { get; set; }
        public string Position { get; set; }

        public void Work()
        {
            Console.WriteLine("Employee working...");
        }

        public void AttendMeeting()
        {
            Console.WriteLine("Employee attending meeting...");
        }
    }

    public class Manager : IEmployee
    {
        public string Name { get; set; }

        public void Work()
        {
            Console.WriteLine("Manager is planning strategy...");
        }

        public void AttendMeeting()
        {
            Console.WriteLine("Manager attends meeting occasionally...");
        }

        public void ManageTeam()
        {
            Console.WriteLine("Managing team...");
        }
    }
}
