using System;

namespace CodeSmells
{
    public class Course
    {
        private int _credits;
        private bool _isCompleted;

        public int Credits => _credits;
        public bool IsCompleted => _isCompleted;

        public Course(int credits)
        {
            _credits = credits;
            _isCompleted = false;
        }

        public void Complete()
        {
            _isCompleted = true;
        }

        public void SetCredits(int credits)
        {
            _credits = credits;
        }
    }

    public class Student
    {
        public void CompleteCourse(Course course)
        {
            course.SetCredits(3);
            course.Complete();
        }
    }
}
