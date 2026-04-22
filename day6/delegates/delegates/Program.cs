using System;

class Program
{
    delegate void MathOperation(int a, int b);

    static void Add(int a, int b)
    {
        Console.WriteLine("Add: " + (a + b));
    }

    static void Subtract(int a, int b)
    {
        Console.WriteLine("Subtract: " + (a - b));
    }

    static void Multiply(int a, int b)
    {
        Console.WriteLine("Multiply: " + (a * b));
    }

    static void Main()
    {
        Console.Write("Enter first number: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second number: ");
        int b = Convert.ToInt32(Console.ReadLine());

        MathOperation operation = Add;
        operation += Subtract;
        operation += Multiply;

        operation(a, b);
    }
}