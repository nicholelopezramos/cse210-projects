class Program
{
    static void Main()
    {
        // Example scripture and reference
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        Scripture scripture = new Scripture("Trust in the Lord with all thine heart; and lean not unto thine own understanding.", reference);

        // Display original scripture
        Console.WriteLine("Original Scripture:");
        Console.WriteLine(scripture.GetReferenceText() + " " + scripture.GetDisplayText());

        // Hide 3 random words
        scripture.HideRandomWords(3);

        // Display scripture after hiding words
        Console.WriteLine("\nAfter Hiding 3 Words:");
        Console.WriteLine(scripture.GetReferenceText() + " " + scripture.GetDisplayText());

        // Check if all words are hidden
        Console.WriteLine("\nIs completely hidden? " + scripture.IsCompletelyHidden());
    }
}
