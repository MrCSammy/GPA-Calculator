using HelloWorld;
using System;
using System.Collections.Generic;

namespace GPACalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            pratice.Inner();

            List<Course> courses = new List<Course>();

            Console.WriteLine("Enter details for each course (type 'done' to finish):");

            while (true)
            {
                Console.Write("Enter course code and grade (separated by a comma): ");
                string input = Console.ReadLine();

                if (input.ToLower() == "done")
                    break;

                string[] parts = input.Split(',');
                if (parts.Length != 2)
                {
                    Console.WriteLine("Invalid input. Please use the format 'code, grade' (e.g., MTH101, A).");
                    continue;
                }

                string code = parts[0].Trim();
                char grade = parts[1].Trim().ToUpper()[0];
                if (!IsValidGrade(grade))
                {
                    Console.WriteLine("Invalid input. Please enter a valid grade (A/B/C/D/E/F).");
                    continue;
                }

                courses.Add(new Course(code, grade));
            }

            Console.WriteLine("\nCourse\t\tGrade\t\tGrade Unit\tWeight Point\tRemarks\t");
            Console.WriteLine("-------------------------------------------------------------------------");
            double totalGradePoints = 0;

            foreach (var course in courses)
            {
                double gradePoints = course.GetGradePoints();
                Console.WriteLine($"{course.Code}\t\t{course.Grade}\t\t{course.GradePoint}\t\t{gradePoints:F2}\t\t{GetRemark(course.Grade)}");
                totalGradePoints += gradePoints;
            }

            if (courses.Count > 0)
            {
                double gpa = totalGradePoints / courses.Count;
                Console.WriteLine($"\nTotal GPA: {gpa:F2}");
                if (gpa >= 4.50)
                {
                    Console.WriteLine("Wow that's first class");
                }
                if (gpa < 4.50 && gpa >= 4.00)
                {
                    Console.WriteLine("Wow that's Second class upper");
                }
                if (gpa <4.00 && gpa >= 3.50)
                {
                    Console.WriteLine("Second class lower");
                }
                if (gpa <3.50 && gpa >= 2.00)
                {
                    Console.WriteLine("This is third class");
                }
                if (gpa < 2.00)
                {
                    Console.WriteLine("Pass");
                }
            }
            else
            {
                Console.WriteLine("No courses entered. GPA cannot be calculated.");
            }
        }

        static bool IsValidGrade(char grade)
        {
            return grade == 'A' || grade == 'B' || grade == 'C' || grade == 'D' || grade == 'F' || grade == 'E';
        }

        static string GetRemark(char grade)
        {
            switch (grade)
            {
                case 'A': return "Excellent";
                case 'B': return "Very Good";
                case 'C': return "Good";
                case 'D': return "Fair";
                case 'E': return "Poor";
                default: return "Fail";
            }
        }
    }

    class Course
    {
        public string Code { get; }
        public char Grade { get; }
        public int GradePoint => Grade switch
        {
            'A' => 5,
            'B' => 4,
            'C' => 3,
            'D' => 2,
            'E' => 1,
            _ => 0
        };

        public Course(string code, char grade)
        {
            Code = code;
            Grade = grade;
        }

        public double GetGradePoints()
        {
            return GradePoint;
        }
    }
}
