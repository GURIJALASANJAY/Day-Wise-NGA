using System;
using System.Collections.Generic;

class Student
{
    public string Name;
    public int Marks;
    public int Attendance;
    public int Participation;
}

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>();

        Console.Write("Enter number of students: ");
        int n = int.Parse(Console.ReadLine());

        // Input Section
        for (int i = 0; i < n; i++)
        {
            Student s = new Student();

            Console.WriteLine($"\nEnter details for Student {i + 1}:");

            Console.Write("Name: ");
            s.Name = Console.ReadLine();

            Console.Write("Marks: ");
            s.Marks = int.Parse(Console.ReadLine());

            Console.Write("Attendance: ");
            s.Attendance = int.Parse(Console.ReadLine());

            Console.Write("Participation: ");
            s.Participation = int.Parse(Console.ReadLine());

            students.Add(s);
        }

        // Anonymous Method → Calculate Total
        Func<Student, int> calculateTotal = delegate (Student s)
        {
            return s.Marks + s.Attendance + s.Participation;
        };

        // Lambda Expression → Display Performance
        Action<Student> display = s =>
        {
            int total = calculateTotal(s);

            Console.WriteLine($"\nName: {s.Name}");
            Console.WriteLine($"Total Score: {total}");

            if (total > 200)
                Console.WriteLine("Performance: Excellent");
            else if (total > 150)
                Console.WriteLine("Performance: Good");
            else
                Console.WriteLine("Performance: Average");
        };

        // Lambda → Eligibility Check
        Predicate<Student> isEligible = s => s.Marks > 50;

        // Lambda → Top Performers Filter
        Predicate<Student> topPerformer = s => s.Marks > 75;

        // Output Section
        Console.WriteLine("\n===== All Students =====");
        students.ForEach(display);

        Console.WriteLine("\n===== Eligible Students (Marks > 50) =====");
        students.FindAll(isEligible).ForEach(display);

        Console.WriteLine("\n===== Top Performers (Marks > 75) =====");
        students.FindAll(topPerformer).ForEach(display);

        Console.WriteLine("\nProgram Completed Successfully!");
        Console.ReadLine();
    }
}