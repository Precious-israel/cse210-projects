using System;

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent()
    {
        if (!IsCompleted)
        {
            MarkComplete();
            return Points;
        }
        return 0;
    }
}

