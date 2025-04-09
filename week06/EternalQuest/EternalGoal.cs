using System;
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent() => points;

    public override bool IsComplete() => false;

    public override string GetStatus() => $"[∞] {name} - {description}";

    public override string GetGoalType() => "Eternal";

    public override string SaveData() => $"{GetGoalType()}|{name}|{description}|{points}";

    public override void LoadData(string data)
    {
        var parts = data.Split('|');
        name = parts[1];
        description = parts[2];
        points = int.Parse(parts[3]);
    }
}