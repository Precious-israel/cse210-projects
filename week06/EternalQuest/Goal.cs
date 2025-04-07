using System;
using System.Collections.Generic;

public abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }
    public bool IsCompleted { get; set; }

    public Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
        IsCompleted = false;
    }

    public abstract int RecordEvent();

    public virtual void Display()
    {
        string status = IsCompleted ? "Completed" : "Not Completed";
        Console.WriteLine($"{Name}: {status} - {Description} ({Points} points)");
    }

    public virtual void MarkComplete()
    {
        IsCompleted = true;
    }

    public virtual Dictionary<string, object> Save()
    {
        return new Dictionary<string, object>
        {
            { "Name", Name },
            { "Description", Description },
            { "Points", Points },
            { "IsCompleted", IsCompleted }
        };
    }

    public static Goal Load(Dictionary<string, object> data)
    {
        if (data.ContainsKey("Target"))
        {
            return ChecklistGoal.Load(data);
        }
        else if (data.ContainsKey("Count"))
        {
            return EternalGoal.Load(data);
        }
        else
        {
            return new SimpleGoal(
                data["Name"].ToString(),
                data["Description"].ToString(),
                Convert.ToInt32(data["Points"])
            );
        }
    }
}
