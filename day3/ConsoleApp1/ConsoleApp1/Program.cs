using System;

namespace ConsoleApp_Csharp.Day2
{
    // Student class
    class Student
    {
        string name;
        int id;

        // Constructor
        public Student(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

        // Display method
        public void Display()
        {
            Console.WriteLine("Name: " + name + ", ID: " + id);
        }

        // Update method
        public void UpdateDetails(string name, int id)
        {
            this.name = name;
            this.id = id;
        }
    }

    // Main Program class
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            Student s1 = new Student("sneha", 916);
            Student s2 = new Student("alok", 245);

            s1.Display();
            s2.Display();

            s1.UpdateDetails("virat", 975);
            s2.UpdateDetails("viraj", 127);

            s1.Display();
            s2.Display();
        }
    }
}