using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep3 World!");

        Random randomNumber = new Random();
        int ranNumber = randomNumber.Next(1, 101);

        int guess = -1;

        while (guess != ranNumber)

        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (ranNumber > guess)

        {
            Console.WriteLine("Higher");
            }
            else if (ranNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");

            }
            
        }
    }
}