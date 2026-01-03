using System;
using System.Collections.Generic;

namespace Observer
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var lecturer = new Lecturer("Adam");

            lecturer.Register(new Student("Alicja"));
            lecturer.Register(new Student("Robert"));
            lecturer.Register(new Student("Mateusz"));

            var results = new Dictionary<string, int>
            {
                ["Alicja"] = 85,
                ["Robert"] = 73,
                ["Mateusz"] = 92
            };

            lecturer.AnnounceResults(results);
        }
    }
}