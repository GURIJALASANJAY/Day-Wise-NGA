using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace features_of_c_
{
    interface ITest
    {
        void Show() => Console.WriteLine("Default Interface Method");
    }

    readonly struct Demo
    {
        public readonly int Get() => 1;
    }

    internal class Program : ITest
    {
        static async Task Main(string[] args)
        {
            // 1. Tuples
            var t = (1, 2);
            Console.WriteLine($"Tuple: {t.Item1}, {t.Item2}");

            // 2. Named Tuple + Deconstruction
            var person = (name: "Sanjay", age: 21);
            var (n, a) = person;
            Console.WriteLine($"Name: {n}, Age: {a}");

            // 3. Pattern Matching
            object obj = 10;
            if (obj is int x)
                Console.WriteLine($"Pattern Matching: {x}");

            // 4. Local Function + Expression-bodied
            int Add(int a1, int b1) => a1 + b1;
            Console.WriteLine($"Local Function: {Add(2, 3)}");

            // 5. Ref Returns
            int[] arr = { 10, 20 };
            ref int refVal = ref arr[0];
            refVal = 50;
            Console.WriteLine($"Ref Return: {arr[0]}");

            // 6. Out Variable
            int.TryParse("123", out int num);
            Console.WriteLine($"Out Variable: {num}");

            // 7. Throw Expression
            string str = null;
            try
            {
                string result = str ?? throw new Exception("Null value");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // 8. Numeric Literal
            int big = 1_000_000;
            Console.WriteLine($"Numeric Literal: {big}");

            // 9. Nullable Reference Type
            string? name = null;
            Console.WriteLine($"Nullable: {name}");

            // 10. Switch Expression
            int val = 1;
            string res = val switch
            {
                1 => "One",
                _ => "Other"
            };
            Console.WriteLine($"Switch Expression: {res}");

            // 11. Using Declaration
            using var reader = new StringReader("Hello");
            Console.WriteLine($"Using Declaration: {reader.ReadLine()}");

            // 12. Ranges
            int[] nums = { 1, 2, 3, 4, 5 };
            var slice = nums[1..3];
            Console.WriteLine($"Range: {string.Join(",", slice)}");

            // 13. Property Pattern
            var p = new { Age = 20 };
            if (p is { Age: > 18 })
                Console.WriteLine("Property Pattern: Adult");

            // 14. Static Local Function
            static int Square(int x1) => x1 * x1;
            Console.WriteLine($"Static Local Function: {Square(5)}");

            // 15. Null-Coalescing Assignment
            string s = null;
            s ??= "Default Value";
            Console.WriteLine($"Null-Coalescing: {s}");

            // 16. Default Interface Method
            Program prog = new Program();
            prog.Show();

            // 17. Readonly Struct
            Demo d = new Demo();
            Console.WriteLine($"Readonly Struct: {d.Get()}");

            // 18. Async/Await + Async Stream
            await foreach (var item in GetData())
            {
                Console.WriteLine($"Async Stream: {item}");
            }
        }

        // Async Stream
        static async IAsyncEnumerable<int> GetData()
        {
            await Task.Delay(100);
            yield return 1;
            yield return 2;
        }
    }
}