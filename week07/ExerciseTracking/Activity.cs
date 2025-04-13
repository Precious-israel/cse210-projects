using System;

public abstract class Activity
{
    protected DateTime _date;
    protected int _duration;

    public Activity(DateTime date, int duration)
    {
        _date = date;
        _duration = duration;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {this.GetType().Name} ({_duration} min) - " +
               $"Distance {GetDistance():F1}, Speed {GetSpeed():F1}, Pace: {GetPace():F1} min per {GetDistanceUnit()}";
    }

    protected virtual string GetDistanceUnit()
    {
        return "mile";
    }
}

