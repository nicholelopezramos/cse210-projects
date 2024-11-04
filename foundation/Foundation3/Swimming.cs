public class Swimming : Activity
{
    private int laps;

    public Swimming(int minutes, DateTime date, int laps)
        : base(minutes, date)
    {
        this.laps = laps;
    }

    public override double GetDistance() => laps * 50 / 1000.0 * 0.62;

    public override double GetSpeed() => (GetDistance() / Minutes) * 60;

    public override double GetPace() => Minutes / GetDistance();
}