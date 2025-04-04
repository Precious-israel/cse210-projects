public class ReflectingActivity : Activity
{
    private static readonly List<string> Prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly List<string> Questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private static readonly List<string> UsedPrompts = new List<string>();
    private static readonly List<string> UsedQuestions = new List<string>();

    public ReflectingActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public override void PerformActivity(int duration)
    {
        StartActivity();
        Console.WriteLine("Prepare to begin...");
        DisplaySpinner(3);

        Random rand = new Random();

        // Ensure prompts and questions are not repeated until all have been used
        if (UsedPrompts.Count == Prompts.Count)
        {
            UsedPrompts.Clear();  // Reset used prompts when all have been used
        }

        string prompt = Prompts[rand.Next(Prompts.Count)];
        while (UsedPrompts.Contains(prompt))  // Ensure no prompt repeats
        {
            prompt = Prompts[rand.Next(Prompts.Count)];
        }
        UsedPrompts.Add(prompt);

        Console.WriteLine($"Prompt: {prompt}");
        DisplaySpinner(3);

        if (UsedQuestions.Count == Questions.Count)
        {
            UsedQuestions.Clear();  // Reset used questions when all have been used
        }

        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            string question = Questions[rand.Next(Questions.Count)];
            while (UsedQuestions.Contains(question))  // Ensure no question repeats
            {
                question = Questions[rand.Next(Questions.Count)];
            }
            UsedQuestions.Add(question);

            Console.WriteLine($"Question: {question}");
            DisplaySpinner(4);  // Pause between questions
        }

        EndActivity(duration);
    }
}
