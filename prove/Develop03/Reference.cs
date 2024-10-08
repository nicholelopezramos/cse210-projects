public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse, int endVerse = 0)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse > 0 ? endVerse : verse; 
    }

    public string GetDisplayText()
    {
        return _endVerse > _verse 
            ? $"{_book} {_chapter}:{_verse}-{_endVerse}" 
            : $"{_book} {_chapter}:{_verse}";
    }
}