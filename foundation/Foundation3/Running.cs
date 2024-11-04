public class Running : Activity
{
    private double distanceMiles;

    public Running(int minutes, DateTime date, double distanceMiles)
        : base(minutes, date)
    {
        this.distanceMiles = distanceMiles;
    }

    public override double GetDistance() => distanceMiles;

    public override double GetSpeed() => (distanceMiles / Minutes) * 60;

    public override double GetPace() => Minutes / distanceMiles;
}