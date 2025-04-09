using System;

public class SimpleGoal : Goal
{
    private bool completed;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        completed = false;
    }

    public override int RecordEvent()
    {
        if (!completed)
        {
            completed = true;
            return points;
        }
        return 0;
    }

    public override bool IsComplete() => completed;

    public override string GetStatus() => $"[ {(completed ? "X" : " ")} ] {name} - {description}";

    public override string GetGoalType() => "Simple";

    public override string SaveData() => $"{GetGoalType()}|{name}|{description}|{points}|{completed}";

    public override void LoadData(string data)
    {
        var parts = data.Split('|');
        name = parts[1];
        description = parts[2];
        points = int.Parse(parts[3]);
        completed = bool.Parse(parts[4]);
    }
}

