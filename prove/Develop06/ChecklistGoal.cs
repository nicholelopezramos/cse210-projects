public class ChecklistGoal : Goal
{
    private int _amountComplete;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string shortName, string description, int points, int target, int bonus)
        : base(shortName, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountComplete = 0;
    }

    // Public property to access bonus points outside the class
    public int BonusPoints => _bonus;

    public override void RecordEvent()
    {
        _amountComplete++;
        Console.WriteLine($"{_shortName} recorded! You've earned {_points} points.");

        if (IsComplete())
        {
            Console.WriteLine($"{_shortName} goal completed! Bonus: {_bonus} points.");
        }
    }

    public override bool IsComplete() => _amountComplete >= _target;

    public override string GetDetailsString() => $"{_shortName}: {_description} ({_amountComplete}/{_target} times completed)";

    public override string GetStringRepresentation() => $"ChecklistGoal|{_shortName}|{_description}|{_points}|{_target}|{_bonus}|{_amountComplete}";
}
