using System;

namespace CodeSmells
{
    public class School
    {
        public Classroom GetClassroom()
        {
            return new Classroom();
        }

        public string GetTeacherName()
        {
            return GetClassroom().GetTeacher().GetName();
        }
    }

    public class Classroom
    {
        public Teacher GetTeacher()
        {
            return new Teacher();
        }
    }

    public class Teacher
    {
        public string GetName()
        {
            return "John Smith";
        }
    }
}
