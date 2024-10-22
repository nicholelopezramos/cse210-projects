using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness App");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Select an activity (1-4): ");
            string choice = Console.ReadLine();

            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            if (activity != null)
            {
                activity.RunActivity();
            }

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
        }
    }
}

abstract class Activity
{
    // Private member variables for encapsulation
    private int duration;

    // Public method to control the flow of the activity
    public void RunActivity()
    {
        DisplayStartingMessage();
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);  // Pause before starting

        ExecuteActivity();

        DisplayEndingMessage();
    }

    // Protected method to avoid duplication in derived classes
    protected void SetDuration()
    {
        Console.Write("Enter the duration of the activity in seconds: ");
        duration = int.Parse(Console.ReadLine());
    }

    // Protected method to access duration, following encapsulation
    protected int GetDuration()
    {
        return duration;
    }

    // Common method to display starting message
    private void DisplayStartingMessage()
    {
        SetDuration();
        Console.WriteLine($"{GetType().Name} Activity:");
        Console.WriteLine(GetDescription());
    }

    // Common method to display ending message
    private void DisplayEndingMessage()
    {
        Console.WriteLine("Good job! You have completed the activity.");
        ShowSpinner(3);
        Console.WriteLine($"You completed the {GetType().Name} Activity for {duration} seconds.");
        ShowSpinner(3);
    }

    // Utility method for a simple spinner animation
    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    // Abstract methods to enforce implementation in derived classes
    protected abstract string GetDescription();
    protected abstract void ExecuteActivity();
}

class BreathingActivity : Activity
{
    protected override string GetDescription()
    {
        return "This activity will help you relax by guiding you through slow, deep breathing.";
    }

    protected override void ExecuteActivity()
    {
        int cycles = GetDuration() / 6;  // Each cycle: 3 seconds in, 3 seconds out

        for (int i = 0; i < cycles; i++)
        {
            Console.WriteLine("Breathe in...");
            ShowSpinner(3);

            Console.WriteLine("Breathe out...");
            ShowSpinner(3);
        }
    }
}

class ReflectionActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "How did you feel when it was complete?",
        "What did you learn from this experience?",
        "How can you apply this experience in the future?"
    };

    protected override string GetDescription()
    {
        return "This activity will help you reflect on moments of strength and resilience in your life.";
    }

    protected override void ExecuteActivity()
    {
        Random random = new Random();
        Console.WriteLine(prompts[random.Next(prompts.Count)]);

        for (int i = 0; i < GetDuration() / 5; i++)
        {
            Console.WriteLine(questions[random.Next(questions.Count)]);
            ShowSpinner(5);
        }
    }
}

class ListingActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "List people you appreciate.",
        "List personal strengths.",
        "List people you have helped this week.",
        "List your personal heroes."
    };

    private List<string> userInputs = new List<string>();

    protected override string GetDescription()
    {
        return "This activity will help you reflect on positive things by listing them.";
    }

    protected override void ExecuteActivity()
    {
        Random random = new Random();
        Console.WriteLine(prompts[random.Next(prompts.Count)]);
        ShowSpinner(5);
        Console.WriteLine("Start listing as many items as you can:");

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                userInputs.Add(input);
            }
        }

        Console.WriteLine($"You listed {userInputs.Count} items.");
    }
}
