using System;
using System.Collections.Generic;

public class EternalGoal : Goal
{
    public int Count { get; set; }
    public bool IsCompleted { get; set; }

    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
        Count = 0;
        IsCompleted = false;
    }

    public override int RecordEvent()
    {
        Count++;
        IsCompleted = false;
        return Points;
    }

    public override void Display()
    {
        Console.WriteLine($"[Eternal] {Name} - {Description}. Points per event: {Points}. Completed: {IsCompleted}");
    }

    public override Dictionary<string, object> Save()
    {
        return new Dictionary<string, object>
        {
            { "Name", Name },
            { "Description", Description },
            { "Points", Points },
            { "Count", Count },
            { "IsCompleted", IsCompleted }
        };
    }

    public new static EternalGoal Load(Dictionary<string, object> data)
    {
        var goal = new EternalGoal(
            data["Name"].ToString(),
            data["Description"].ToString(),
            Convert.ToInt32(data["Points"])
        )
        {
            Count = Convert.ToInt32(data["Count"]),
            IsCompleted = Convert.ToBoolean(data["IsCompleted"])
        };
        return goal;
    }
}
