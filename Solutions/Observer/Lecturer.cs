using System;
using System.Collections.Generic;

namespace Observer
{
    public class Lecturer : ILecturer
    {
        private readonly List<IStudentObserver> _students = new();

        public string Name { get; }
        public Lecturer(string name) => Name = name;

        public void Register(IStudentObserver student)
        {
            if (!_students.Contains(student))
                _students.Add(student);
        }

        public void Unregister(IStudentObserver student)
        {
            _students.Remove(student);
        }

        public void AnnounceResults(Dictionary<string,int> results)
        {
            Console.WriteLine($"Lecturer {Name} announces results:");
            foreach (var student in _students)
            {
                if (results.TryGetValue(student.Name, out var grade))
                    student.Update(grade);
                else
                    Console.WriteLine($" - No result for {student.Name}");
            }
        }
    }
}