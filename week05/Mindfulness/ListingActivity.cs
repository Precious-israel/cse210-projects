using System;

public class ListingActivity : Activity
{
    private static List<string> Prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list them.")
    {
    }

    public override void PerformActivity(int duration)
    {
        StartActivity();  // Starting the activity
        Console.WriteLine("Prepare to begin...");
        DisplaySpinner(3);  // Short pause before the activity starts

        Random rand = new Random();
        string prompt = Prompts[rand.Next(Prompts.Count)];
        Console.WriteLine($"Prompt: {prompt}");
        Console.WriteLine("Start listing items. You have limited time!");

        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        // Input loop until time runs out
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item))
                items.Add(item);
        }

        Console.WriteLine($"You listed {items.Count} items!");
        EndActivity(duration);  // End the activity and provide feedback
    }
}

