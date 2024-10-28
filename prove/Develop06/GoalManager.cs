using System;
using System.Collections.Generic;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public int Score => _score;

    public void Start()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine($"\nMenu Options:");
            Console.WriteLine($"1. Create a new goal");
            Console.WriteLine($"2. List goals");
            Console.WriteLine($"3. Load goals");
            Console.WriteLine($"4. Record Event");
            Console.WriteLine("5. Quit");

            Console.Write("\nEnter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    LoadGoalsFromFile(); // Renamed method
                    break;
                case "4":
                    RecordEvent();
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe Types of Goal are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("\nWhich type of goal would you like to create? ");

        string goalTypeChoice = Console.ReadLine();
        Console.Write("Enter the name of your goal: ");
        string name = Console.ReadLine();
        Console.Write("Enter a short description of your goal: ");
        string description = Console.ReadLine();
        Console.Write("Enter the amount of points associated with this goal: ");
        int points = int.Parse(Console.ReadLine());

        switch (goalTypeChoice)
        {
            case "1": // Simple Goal
                _goals.Add(new SimpleGoal(name, description, points));
                Console.WriteLine("Simple goal created successfully!");
                break;

            case "2": // Eternal Goal
                _goals.Add(new EternalGoal(name, description, points));
                Console.WriteLine("Eternal goal created successfully!");
                break;

            case "3": // Checklist Goal
                Console.Write("Enter the target count (times to complete): ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter the bonus points for completing this goal: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                Console.WriteLine("Checklist goal created successfully!");
                break;

            default:
                Console.WriteLine("Invalid goal type choice.");
                break;
        }
    }

    public void ListGoals()
    {
        Console.WriteLine("\nGoals:");
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    // Renamed method for loading goals
    public void LoadGoalsFromFile() 
    {
        // Implement load functionality here
        Console.WriteLine("Load goals functionality not implemented yet.");
    }

    public void RecordEvent()
    {
        Console.WriteLine("\nSelect goal by number to record an event:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        Console.Write("\nEnter the number of the goal you completed: ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            Goal goal = _goals[goalIndex];
            goal.RecordEvent();
            _score += goal.Points + (goal is ChecklistGoal checklistGoal && checklistGoal.IsComplete() ? checklistGoal.BonusPoints : 0);
            Console.WriteLine($"Current score: {_score}");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    // Placeholder method for saving goals
    public void SaveGoals() 
    { 
        // Implement save functionality 
    }
}
