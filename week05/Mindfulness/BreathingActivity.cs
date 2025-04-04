public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void PerformActivity(int duration)
    {
        StartActivity();  // Starting the activity
        Console.WriteLine("Prepare to begin...");
        DisplaySpinner(3);  // Short pause before the activity starts

        // Loop for breathing, incrementing by 2 seconds for each "inhale-exhale" cycle
        for (int i = 0; i < duration; i += 2)
        {
            Console.WriteLine("Breathe in...");
            DisplaySpinner(1);  // 1 second for inhale
            Console.WriteLine("Breathe out...");
            DisplaySpinner(1);  // 1 second for exhale
        }

        // Handle any remaining seconds if the duration was odd
        if (duration % 2 != 0)
        {
            Console.WriteLine("Breathe in...");
            DisplaySpinner(1);
            Console.WriteLine("Breathe out...");
            DisplaySpinner(1);
        }

        EndActivity(duration);  // End the activity and provide feedback
    }
}
    


