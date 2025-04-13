using System;


public class Program
{
    public static void Main(string[] args)
    {
        // Create activities
    List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2024, 4, 13), 30, 3.0),
            new Cycling(new DateTime(2024, 4, 14), 45, 15.0),
            new Swimming(new DateTime(2024, 4, 15), 25, 20)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
