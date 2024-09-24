using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep4 World!");

        List<int> numbers = new List<int>();
        int input = -1; 

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Input loop
        while (input != 0)
        {
            Console.Write("Enter number: ");
            input = int.Parse(Console.ReadLine());

            if (input != 0)  // Append to the list if it's not 0
            {
                numbers.Add(input);
            }
        }

        // Core Requirements
        // Compute the sum
        int sum = numbers.Sum();
        
        // Compute the average
        double average = numbers.Average();
        
        // Find the largest number
        int max = numbers.Max();

        // Output results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
    
    }
}