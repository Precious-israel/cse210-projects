using System;
using System.Collections.Generic;
using System.IO;

public class Entry
{
    public string Date { get; set; }
    public string Title { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Mood { get; set; }
    public string Tags { get; set; } // Comma-separated tags
}

public class Journal
{
    private readonly List<Entry> _entries = new List<Entry>();
    private static readonly Random _random = new Random();

    private static readonly List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "Who exactly disrupted my activity today?",
        "What is my greatest achievement today?",
        "Did I win any soul for Christ today?"
    };

    public void AddEntry()
    {
        string date = DateTime.Now.ToString("yyyy-MM-dd");
        Console.Write("Enter a title for your journal entry: ");
        string title = Console.ReadLine();

        string prompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine(prompt);
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        Console.Write("How was your mood? (e.g., Happy, Sad, Excited): ");
        string mood = Console.ReadLine();

        Console.Write("Enter tags for this entry (comma-separated): ");
        string tags = Console.ReadLine();

        _entries.Add(new Entry
        {
            Date = date,
            Title = title,
            Prompt = prompt,
            Response = response,
            Mood = mood,
            Tags = tags
        });

        Console.WriteLine("Entry added successfully!\n");
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries available.\n");
            return;
        }

        foreach (var entry in _entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Title: {entry.Title}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}");
            Console.WriteLine($"Mood: {entry.Mood}");
            Console.WriteLine($"Tags: {entry.Tags}");
            Console.WriteLine(new string('-', 40));
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Title}|{entry.Prompt}|{entry.Response}|{entry.Mood}|{entry.Tags}");
            }
        }

        Console.WriteLine("Journal saved successfully!\n");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.\n");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);

        foreach (var line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 6)
            {
                _entries.Add(new Entry
                {
                    Date = parts[0],
                    Title = parts[1],
                    Prompt = parts[2],
                    Response = parts[3],
                    Mood = parts[4],
                    Tags = parts[5]
                });
            }
        }

        Console.WriteLine("Journal loaded successfully!\n");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Journal journal = new Journal();
        string choice = string.Empty;

        while (choice != "5")
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Enter your choice: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.AddEntry();
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter filename: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;
                case "4":
                    Console.Write("Enter filename: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;
                case "5":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.\n");
                    break;
            }
        }
    }
}
