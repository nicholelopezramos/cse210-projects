public class Program
{
    public static void Main()
    {
        // Create instances of each activity
        var activities = new List<Activity>
        {
            new Running(40, DateTime.Now, 4.0),  // 4 miles in 40 minutes
            new Cycling(50, DateTime.Now, 16.0), // 16 miles in 50 minutes
            new Swimming(30, DateTime.Now, 25)   // 25 laps in 30 minutes
        };

        // Display summary of each activity
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
