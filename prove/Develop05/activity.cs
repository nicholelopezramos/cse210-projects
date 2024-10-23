abstract class Activity
{
    // Private member variables for encapsulation
    private int duration;

    // Public method to control the flow of the activity
    public void RunActivity()
    {
        DisplayStartingMessage();
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);  
        ExecuteActivity();

        DisplayEndingMessage();
    }

    // Protected method to avoid duplication in derived class
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
