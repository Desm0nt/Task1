using System;

namespace ConsoleApp1
{
    public class Student
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public int CourseNumber { set; get; }
        public string Group { set; get; }
        public Mark[] Marks { set; get; }

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