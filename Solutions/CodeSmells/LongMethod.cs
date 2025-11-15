using System;

namespace CodeSmells
{
    public class GradeBook
    {
        private int _grade;
        private bool _isFinalized;

        public int Grade => _grade;
        public bool IsFinalized => _isFinalized;

        public void SetGrade(int value)
        {
            _grade = value;
        }

        public void FinalizeGrades()
        {
            _isFinalized = true;
        }
    }

    public class Teacher
    {
        public void FinalizeGrades(GradeBook gradeBook)
        {
            gradeBook.SetGrade(90);
            gradeBook.FinalizeGrades();
        }
    }
}
