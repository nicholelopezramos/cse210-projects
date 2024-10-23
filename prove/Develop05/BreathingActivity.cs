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