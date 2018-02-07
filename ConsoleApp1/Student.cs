using System;

namespace ConsoleApp1
{
    public class Student
    {
        public string FirstName { get; }
        public string LastName { get; }
        public int CourseNumber { set; get; }
        public string Group { set; get; }
        public Mark[] Marks { set; get; }
        private int Age, EntYear, GradYear;
        private bool badStudent = false;

        public Student(string fname, string lname, int course, string group, Mark[] marks, int age, int entYear)
        {
            FirstName = fname;
            LastName = lname;
            CourseNumber = course;
            Group = group;
            Marks = marks;
            Age = age;
            EntYear = entYear;
            GradYear = entYear + 5 - CourseNumber;
            Console.WriteLine("\nNew student successfully added." +
                              "\nName: " + FirstName + " " + LastName + ", Age :" + Age + 
                              "\nCourse: " + CourseNumber + ", Group: " + Group +
                              "\nEnterance: "+ EntYear + ", Graduate: " + GradYear);
            Console.WriteLine("Studied Disciplines:");
            foreach (var mark in Marks)
            {
                Console.WriteLine(mark.Discipline);
                if (mark.Grade < 5)
                    badStudent = true;
            }
            if (badStudent)
            {
                Console.WriteLine("It's a very bad student with awful marks");
            }
            double Avrg = GetAvgMark();
            if (Avrg >5 && Avrg < 7)
                Console.WriteLine("Student have medium stipend");
            if (Avrg > 7 )
                Console.WriteLine("Student have hing stipend");
            Console.WriteLine("\n\n");
        }

        public double GetAvgMark()
        {
            double avgValue = 0;
            double sum = 0;
            if (Marks.Length > 0)
            {
                foreach (var mark in Marks)
                {
                    sum += mark.Grade;
                }
                avgValue = sum / Marks.Length;
            }
            else
            {
                Console.WriteLine("Mark array probably empty.");
            }
            return avgValue;
        }

        public void ResetAllMark()
        {
            foreach (var mark in Marks)
            {
                mark.Grade = 0;
            }
        }

    }
}