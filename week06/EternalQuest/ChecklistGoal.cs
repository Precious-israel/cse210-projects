using System;

public class ChecklistGoal : Goal
{
    private int targetCount;
    private int currentCount;
    private int bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus)
        : base(name, description, points)
    {
        this.targetCount = targetCount;
        this.bonus = bonus;
        currentCount = 0;
    }

    public override int RecordEvent()
    {
        if (currentCount < targetCount)
        {
            currentCount++;
            return currentCount == targetCount ? points + bonus : points;
        }
        return 0;
    }

    public override bool IsComplete() => currentCount >= targetCount;

    public override string GetStatus() => $"[ {(IsComplete() ? "X" : " ")} ] {name} - {description} (Completed {currentCount}/{targetCount})";

    public override string GetGoalType() => "Checklist";

    public override string SaveData() => $"{GetGoalType()}|{name}|{description}|{points}|{targetCount}|{currentCount}|{bonus}";

    public override void LoadData(string data)
    {
        var parts = data.Split('|');
        name = parts[1];
        description = parts[2];
        points = int.Parse(parts[3]);
        targetCount = int.Parse(parts[4]);
        currentCount = int.Parse(parts[5]);
        bonus = int.Parse(parts[6]);
    }
}
