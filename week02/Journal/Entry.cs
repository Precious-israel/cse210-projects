using System;

public class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;

    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }

    public string Date => _date;
    public string PromptText => _promptText;
    public string EntryText => _entryText;

    public override string ToString()
    {
        return $"Date: {_date}\nPrompt: {_promptText}\nEntry: {_entryText}";
    }
}

