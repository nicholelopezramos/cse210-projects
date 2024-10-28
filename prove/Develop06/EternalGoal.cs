public class EternalGoal : Goal
{
    public EternalGoal(string shortName, string description, int points)
        : base(shortName, description, points) { }

    public override void RecordEvent()
    {
        Console.WriteLine($"{_shortName} recorded! You've earned {_points} points.");
    }

    public override bool IsComplete() => false;

    public override string GetDetailsString() => $"{_shortName}: {_description}";

    public override string GetStringRepresentation() => $"EternalGoal|{_shortName}|{_description}|{_points}";
}
