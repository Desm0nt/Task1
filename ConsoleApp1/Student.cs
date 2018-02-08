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
            int gradAge = GetGraduateAge(Age, CourseNumber); // params use for task2
            Console.WriteLine("\nNew student successfully added." +
                              "\nName: " + FirstName + " " + LastName + ", Age :" + Age + 
                              "\nCourse: " + CourseNumber + ", Group: " + Group +
                              "\nEnterance: "+ EntYear + ", Graduate: " + GradYear + ", Graduate Age: " + gradAge);
            Console.WriteLine("Studied Disciplines:");
            foreach (var mark in Marks) // continue use for task2
            {
                Console.WriteLine(mark.Discipline);
                if (mark.Grade >= 5)
                    continue; // continue use for task2
                badStudent = true;
            }
            if (badStudent)
            {
                Console.WriteLine("It's a very bad student with awful marks");
            }
            int? stpSize; // nullable int for task2
            CheckStipendSize(out stpSize); // modificators use for task2
            if (stpSize != null)
                Console.WriteLine("The student have " + stpSize + " rub stipend");

        }

        public void CheckStipendSize( out int? stpSize) // modificators use for task2
        {
            double avrg = GetAvgMark();
            int stpGroup = 0;
            try // try-catch use for task2
            {
                if (avrg < 4)
                    stpGroup = 0;
                else if (avrg >= 4 && avrg < 5)
                    stpGroup = 1;
                else if (avrg >= 5 && avrg < 8)
                    stpGroup = 2;
                else if (avrg == 0)
                    throw new NoMarksException("Probably no exist marks for this student or it's nulled"); // throw use for task2
                else stpGroup = 3;
            }
            catch (NoMarksException ex) { Console.WriteLine(ex.Message); }
        
            switch (stpGroup) // switch with goto and brak for task2
            {
                case 0:
                    goto default;
                case 1:
                    stpSize = 36;
                    break;
                case 2:
                    stpSize = 60;
                    break;
                case 3:
                    stpSize = 89;
                    break;
                default:
                    stpSize = null;
                    Console.WriteLine("Student is close to being dropped from university");
                    break;
            }
        }

        public int GetGraduateAge(params int[] arr) // params use for task2
        {
            int gradAge;
            gradAge = arr[0] + 5 - arr[1];
            return gradAge;
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
    public class NoMarksException : ApplicationException
    {
        public NoMarksException(string message) : base(message) { }
    }
}