using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter students count:");
            int n = CheckedValue();

            Student[] students = new Student[n];
            for (int i = 0; i < n; i++)
            {
                students[i] = AddStudent(i+1);
            }
            Console.WriteLine("Press A to display Avg Mark, R to reset Marks, I to show Info or E for exit.");
            string key;
            do
            {
                var clk = Console.ReadKey();
                key = clk.Key.ToString();
                int studNum = 0;
                switch (key)
                {
                    case "A":
                        Console.WriteLine("\nEnter student number");
                        studNum = CheckedStudNum(students) - 1;                        
                        double avgMark = students[studNum].GetAvgMark();
                        Console.WriteLine("\nAverage Mark:" + avgMark);
                        break;
                    case "R":
                        Console.WriteLine("\nEnter student number");
                        studNum = CheckedStudNum(students)-1;
                        students[studNum].ResetAllMark();
                        Console.WriteLine("\nAll marks reseted.");
                        break;
                    case "I":
                        Console.WriteLine("\nEnter student number");
                        studNum = CheckedStudNum( students)-1;
                        Console.WriteLine("\nFirst name: " + students[studNum].FirstName + "\nLast name: " + students[studNum].LastName + "\nCourse: " + students[studNum].CourseNumber + "\nGroup: " + students[studNum].Group);
                        break;
                    default:
                        Console.WriteLine("\nPlease press A to display Avg Mark, R to reset Marks, I to show Info or E for exit.");
                        break;
                }
            } while (key != "E");
        }

        static int CheckedValue()
        {
            int j = 0;
            do
            {
                var colString = Console.ReadLine();
                try
                {
                    int.TryParse(colString, out j);
                    if (j <= 0)
                    {
                        Console.WriteLine("Must be more than 0.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Must be int32. Please try again.");
                }
            } while (j <= 0);
            return j;
        }
        static int CheckedStudNum(Student[] students) {
            int stdNum = 0;
            do
            {
                var courseString = Console.ReadLine();
                if (int.TryParse(courseString, out stdNum))
                {
                    if (stdNum < 1 || stdNum > students.Length)
                        Console.WriteLine("Student not exist. Enter number between 1 and " + students.Length + ".");
                }
                else
                    Console.WriteLine("Number must be int32. Please try again.");
            } while (stdNum < 1 || stdNum > students.Length);
            return stdNum;
        }

        static Mark AddMark(int num)
        {
            Console.WriteLine("Enter " + num + " discipline name:");
            string DisName = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter " + num + " discipline mark:");
            int MarkValue = CheckedValue();
            return (new Mark { Discipline = DisName, Grade = MarkValue});
        }

        static Student AddStudent(int num)
        {
            Console.WriteLine("Enter "+ num + " student's First Name:");
            string FName = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter " + num + " student's Last Name:");
            string LName = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter " + num + " student's Course:");
            int CourseNumber = 0;
            do
            {
                var courseString = Console.ReadLine();
                if (int.TryParse(courseString, out CourseNumber))
                {
                    if (CourseNumber < 1 || CourseNumber > 5)
                        Console.WriteLine("Course must be between 1 and 5. Please try again.");
                }
                else
                    Console.WriteLine("Course must be int32. Please try again.");
            } while (CourseNumber < 1 || CourseNumber > 5);
            Console.WriteLine("Enter student's Group:");
            string Group = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter " + num + " student's Age:");
            int Age = 0;
            do
            {
                var ageString = Console.ReadLine();
                if (int.TryParse(ageString, out Age))
                {
                    if (Age < 16 || Age > 50)
                        Console.WriteLine("Age must be between 16 and 50. Please try again.");
                }
                else
                    Console.WriteLine("Age must be int32. Please try again.");
            } while (Age < 16 || Age > 50);
            Console.WriteLine("Enter " + num + " student's Enterance Year:");
            int Year = 0;
            do
            {
                var yearString = Console.ReadLine();
                if (int.TryParse(yearString, out Year))
                {
                    if (Year < 2013 || Year > 2017)
                        Console.WriteLine("Year must be between 2013 and 2017. Please try again.");
                }
                else
                    Console.WriteLine("Year must be int32. Please try again.");
            } while (Year < 2013 || Year > 2017);

            Console.WriteLine("Enter Marks count:");
            int n = CheckedValue();

            Mark[] newMarks = new Mark[n];
            for (int i = 0; i < n; i++)
            {
                newMarks[i] = AddMark(i+1);
            }
            return (new Student (FName, LName, CourseNumber, Group, newMarks, Age, Year));
        }
    }
}
