using System;

class Program
{
    // Binary Search Method
    public static int Search(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] == target)
            {
                return mid;
            }
            else if (arr[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return -1;
    }

    static void Main()
    {
        Console.WriteLine("Enter size of array:");
        int size = int.Parse(Console.ReadLine()!);

        int[] arr = new int[size];

        Console.WriteLine("Enter sorted elements (space-separated):");
        string[] input = Console.ReadLine()!.Split(' ');

        for (int i = 0; i < size; i++)
        {
            arr[i] = int.Parse(input[i]);
        }

        Console.WriteLine("Enter element to search:");
        int target = int.Parse(Console.ReadLine()!);

        int result = Search(arr, target);

        if (result != -1)
        {
            Console.WriteLine($"Element found at index: {result}");
        }
        else
        {
            Console.WriteLine("Element not found");
        }
    }
}