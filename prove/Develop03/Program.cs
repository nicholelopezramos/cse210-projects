class Program
{
    static void Main()
    {
        // Example scripture text and reference
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        Scripture scripture = new Scripture("Trust in the Lord with all thine heart; and lean not unto thine own understanding.", reference);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Scripture:");
            Console.WriteLine(scripture.GetReferenceText() + " " + scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nAll words are hidden. Program will now end.");
                break;
            }

            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
    }
}
