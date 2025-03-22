using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Scripture Library
        List<Scripture> scriptureLibrary = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."),
            new Scripture(new Reference("Psalm", 23, 1, 2), "The Lord is my shepherd, I lack nothing. He makes me lie down in green pastures, he leads me beside quiet waters."),
        };

        // Select a random scripture
        Random random = new Random();
        Scripture selectedScripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];

        while (true)
        {
            Console.Clear();
            selectedScripture.Display();

            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            if (selectedScripture.AllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine("All words are hidden. Program ending.");
                break;
            }

            selectedScripture.HideRandomWords();
        }
    }
}