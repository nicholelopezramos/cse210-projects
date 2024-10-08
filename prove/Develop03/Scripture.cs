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
        _words = text.Split(' ').Select(w => new Word(w)).ToList(); 
    }

    
    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        int hiddenCount = 0;

        while (hiddenCount < numberToHide)
        {
            int index = random.Next(0, _words.Count);
            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hiddenCount++;
            }
        }
    }

   
    public string GetDisplayText()
    {
        return string.Join(" ", _words.Select(w => w.GetDisplayText()));
    }

   
    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    
    public string GetReferenceText()
    {
        return _reference.GetDisplayText();
    }
}