using System;

public class Program
{
    public static void Main()
    {
        GoalManager goalManager = new GoalManager("Player1");

        // Corrected CreateGoal calls with proper arguments
        goalManager.CreateGoal("Read Scriptures", "Read scriptures every day", 100, isEternalGoal: true);
        goalManager.CreateGoal("Attend Temple", "Attend the temple 10 times", 50, target: 10, isEternalGoal: false);

        // Display goals and scores
        goalManager.DisplayGoals();
        goalManager.DisplayScore();

        // Record some events
        goalManager.RecordEvent("Read Scriptures");
        goalManager.RecordEvent("Attend Temple");

        // Save and Load Goals
        string filePath = "goals.json";
        goalManager.SaveGoals(filePath);
        goalManager.LoadGoals(filePath);

        // Display player info and goal details
        goalManager.DisplayPlayerInfo();
        goalManager.ListGoalDetails();
    }
}
