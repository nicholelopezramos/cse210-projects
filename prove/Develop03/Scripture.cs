using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(string text, Reference reference)
    {
        _reference = reference;
        _words = ParseWords(text);
    }

    // Method to create Word objects from the input scripture text
    private List<Word> ParseWords(string text)
    {
        var words = text.Split(' ').Select(w => new Word(w)).ToList();
        return words;
    }

    // Hide a specified number of random words
    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        var visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        if (visibleWords.Count == 0) return; // No visible words left to hide

        int hideCount = Math.Min(numberToHide, visibleWords.Count);

        for (int i = 0; i < hideCount; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index); // Ensure we don’t hide the same word twice
        }
    }

    // Get the full scripture text, with hidden words replaced by "_____"
    public string GetDisplayText()
    {
        return string.Join(" ", _words.Select(w => w.GetDisplayText()));
    }

    // Check if all words are hidden
    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    // Get the scripture reference as a string
    public string GetReferenceText()
    {
        return _reference.GetDisplayText();
    }
}
