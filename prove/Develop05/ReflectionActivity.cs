class ReflectionActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "How did you feel when it was complete?",
        "What did you learn from this experience?",
        "How can you apply this experience in the future?"
    };

    protected override string GetDescription()
    {
        return "This activity will help you reflect on moments of strength and resilience in your life.";
    }

    protected override void ExecuteActivity()
    {
        Random random = new Random();
        Console.WriteLine(prompts[random.Next(prompts.Count)]);

        for (int i = 0; i < GetDuration() / 5; i++)
        {
            Console.WriteLine(questions[random.Next(questions.Count)]);
            ShowSpinner(5);
        }
    }
}
