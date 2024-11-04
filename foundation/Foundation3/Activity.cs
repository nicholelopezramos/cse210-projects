
public abstract class Activity
{
    private int minutes;
    private DateTime date;

    public Activity(int minutes, DateTime date)
    {
        this.minutes = minutes;
        this.date = date;
    }

    public int Minutes => minutes;
    public DateTime Date => date;

    // Virtual methods for distance, speed, and pace calculations
    public virtual double GetDistance() => 0;
    public virtual double GetSpeed() => 0;
    public virtual double GetPace() => 0;

    // Get summary of the activity
    public virtual string GetSummary()
    {
        return $"{date.ToShortDateString()} - {GetType().Name} for {minutes} min: " +
               $"Distance: {GetDistance():0.00} miles, Speed: {GetSpeed():0.00} mph, " +
               $"Pace: {GetPace():0.00} min/mile";
    }
}