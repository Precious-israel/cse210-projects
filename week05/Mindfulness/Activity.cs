public abstract class Activity
{
    private string _name;
    private string _description;

    // The 'Duration' property stores the duration of the activity in seconds.
    public int Duration { get; set; }  // Property to store the activity duration

    // Track the number of times each activity is performed
    public static Dictionary<string, int> ActivityCount = new Dictionary<string, int>
    {
        { "Breathing Activity", 0 },
        { "Reflection Activity", 0 },
        { "Listing Activity", 0 }
    };

    // Constructor to initialize the name and description of the activity
    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // Start the activity by displaying its name and description
    public void StartActivity()
    {
        ActivityCount[_name]++;  // Increment the count for the activity
        Console.WriteLine($"\nStarting {_name}...");
        Console.WriteLine(_description);
        Console.WriteLine("How many seconds would you like to spend on this activity?");
    }

    // End the activity with a good job message
    public void EndActivity(int duration)
    {
        Console.WriteLine($"\nGood job! You completed {_name} for {duration} seconds.");
        DisplaySpinner(3);
    }

    // Display a simple spinner for delay or animation effect
    protected void DisplaySpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("...");
            Thread.Sleep(1000);  // Delay for 1 second
        }
        Console.WriteLine();
    }

    // Abstract method to be implemented by each activity
    public abstract void PerformActivity(int duration);
}
