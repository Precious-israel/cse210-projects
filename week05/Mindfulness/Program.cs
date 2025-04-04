using System;
public class Program
{
    static void Main()
    {
        Dictionary<string, Activity> activities = new Dictionary<string, Activity>
        {
            { "1", new BreathingActivity() },
            { "2", new ReflectingActivity() },
            { "3", new ListingActivity() }
        };

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an activity (1-4): ");
            string choice = Console.ReadLine();

            if (choice == "4")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else if (activities.ContainsKey(choice))
            {
                Console.Write("Enter the duration of the activity in seconds: ");
                if (int.TryParse(Console.ReadLine(), out int duration) && duration > 0)
                {
                    // Set the duration for the activity
                    activities[choice].Duration = duration;

                    // Perform the activity with the given duration
                    activities[choice].PerformActivity(duration);

                    // Display the count of activities performed
                    foreach (var activity in Activity.ActivityCount)
                    {
                        Console.WriteLine($"{activity.Key} has been performed {activity.Value} times.");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid positive number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}
