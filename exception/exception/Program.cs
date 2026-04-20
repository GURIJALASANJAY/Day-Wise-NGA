using System;

namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a value:");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter b value:");
            int b = int.Parse(Console.ReadLine());

            try
            {
                Console.WriteLine("Result: " + (a / b));
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Exception is occurring due to division by zero");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter numbers only.");
            }
            finally
            {
                Console.WriteLine("hi");
            }
        }
    }
}