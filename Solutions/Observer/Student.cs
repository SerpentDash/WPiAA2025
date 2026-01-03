using System;

namespace Observer
{
    public class Student : IStudentObserver
    {
        public string Name { get; }
        public int? LastGrade { get; private set; }

        public Student(string name) => Name = name;

        public void Update(int grade)
        {
            LastGrade = grade;
            Console.WriteLine($"- Student {Name} received result: {grade}");
        }

        public override string ToString() => $"{Name} ({(LastGrade.HasValue ? LastGrade.Value.ToString() : "no result")})";
    }
}