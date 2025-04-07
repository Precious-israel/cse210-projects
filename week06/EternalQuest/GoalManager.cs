using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class GoalManager
{
    private List<Goal> goals = new List<Goal>();
    private int score = 0;
    private string playerName;

    public GoalManager(string playerName)
    {
        this.playerName = playerName;
    }

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordEvent(string goalName)
    {
        foreach (var goal in goals)
        {
            if (goal.Name == goalName)
            {
                int pointsEarned = goal.RecordEvent();
                score += pointsEarned;
                Console.WriteLine($"Event recorded for '{goalName}'! Points earned: {pointsEarned}");
                return;
            }
        }
        Console.WriteLine("Goal not found.");
    }

    public void DisplayGoals()
    {
        foreach (var goal in goals)
        {
            goal.Display();
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Your current score: {score}");
    }

    public void SaveGoals(string filePath)
    {
        var data = new Dictionary<string, object>
        {
            { "Goals", goals.ConvertAll(goal => goal.Save()) },
            { "Score", score },
            { "PlayerName", playerName }
        };

        var jsonString = JsonSerializer.Serialize(data);
        File.WriteAllText(filePath, jsonString);
        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals(string filePath)
    {
        if (File.Exists(filePath))
        {
            var jsonString = File.ReadAllText(filePath);
            var data = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonString);

            score = Convert.ToInt32(data["Score"]);
            playerName = data["PlayerName"].ToString();
            goals.Clear();

            foreach (var goalData in (List<object>)data["Goals"])
            {
                var goalDict = (Dictionary<string, object>)goalData;
                goals.Add(Goal.Load(goalDict));
            }

            Console.WriteLine("Goals and player data loaded successfully.");
        }
        else
        {
            Console.WriteLine("No saved data found, starting fresh.");
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Player Name: {playerName}");
    }

    public void ListGoalNames()
    {
        foreach (var goal in goals)
        {
            Console.WriteLine(goal.Name);
        }
    }

    public void ListGoalDetails()
    {
        foreach (var goal in goals)
        {
            goal.Display();
        }
    }

    public void CreateGoal(string name, string description, int points, int target = 0, bool isEternalGoal = false)
    {
        Goal newGoal;

        if (isEternalGoal)
        {
            newGoal = new EternalGoal(name, description, points);
        }
        else
        {
            newGoal = new ChecklistGoal(name, description, points, target);
        }

        AddGoal(newGoal);
        Console.WriteLine($"Goal '{name}' created.");
    }
}
