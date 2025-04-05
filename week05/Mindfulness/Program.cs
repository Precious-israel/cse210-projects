using System;

using System.Threading; // Required for Thread.Sleep

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

                    // Pause the program for 3 seconds after performing the activity
                    Thread.Sleep(3000);

                    // Display the count of activities performed
                    foreach (var activity in Activity.ActivityCount)
                    {
                        Console.WriteLine($"{activity.Key} has been performed {activity.Value} times.");

                        // Pause for 2 seconds between displaying each activity count
                        Thread.Sleep(2000);
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