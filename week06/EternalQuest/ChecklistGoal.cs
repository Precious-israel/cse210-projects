using System;
using System.Collections.Generic;

public class ChecklistGoal : Goal
{
    public int Target { get; set; }
    public int CompletedCount { get; set; }
    public bool IsCompleted { get; set; }

    public ChecklistGoal(string name, string description, int points, int target)
        : base(name, description, points)
    {
        Target = target;
        CompletedCount = 0;
        IsCompleted = false;
    }

    public override int RecordEvent()
    {
        CompletedCount++;
        IsCompleted = CompletedCount >= Target;
        return Points;
    }

    public override void Display()
    {
        Console.WriteLine($"[Checklist] {Name} - {Description}. Points per event: {Points}. Completed {CompletedCount}/{Target}. Completed: {IsCompleted}");
    }

    public override Dictionary<string, object> Save()
    {
        return new Dictionary<string, object>
        {
            { "Name", Name },
            { "Description", Description },
            { "Points", Points },
            { "Target", Target },
            { "CompletedCount", CompletedCount },
            { "IsCompleted", IsCompleted }
        };
    }

    public new static ChecklistGoal Load(Dictionary<string, object> data)
    {
        var goal = new ChecklistGoal(
            data["Name"].ToString(),
            data["Description"].ToString(),
            Convert.ToInt32(data["Points"]),
            Convert.ToInt32(data["Target"])
        )
        {
            CompletedCount = Convert.ToInt32(data["CompletedCount"]),
            IsCompleted = Convert.ToBoolean(data["IsCompleted"])
        };
        return goal;
    }
}
