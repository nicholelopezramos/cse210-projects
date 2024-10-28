public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string shortName, string description, int points)
        : base(shortName, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
        Console.WriteLine($"{_shortName} completed! You've earned {_points} points.");
    }

    public override bool IsComplete() => _isComplete;

    public override string GetDetailsString() => $"{_shortName}: {_description}";

    public override string GetStringRepresentation() => $"SimpleGoal|{_shortName}|{_description}|{_points}|{_isComplete}";
}
