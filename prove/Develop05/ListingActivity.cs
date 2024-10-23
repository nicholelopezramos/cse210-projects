class ListingActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "List people you appreciate.",
        "List personal strengths.",
        "List people you have helped this week.",
        "List your personal heroes."
    };

    private List<string> userInputs = new List<string>();

    protected override string GetDescription()
    {
        return "This activity will help you reflect on positive things by listing them.";
    }

    protected override void ExecuteActivity()
    {
        Random random = new Random();
        Console.WriteLine(prompts[random.Next(prompts.Count)]);
        ShowSpinner(5);
        Console.WriteLine("Start listing as many items as you can:");

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                userInputs.Add(input);
            }
        }

        Console.WriteLine($"You listed {userInputs.Count} items.");
    }
}
