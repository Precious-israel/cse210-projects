public class Cycling : Activity
{
    private double _speed; // in mph

    public Cycling(DateTime date, int duration, double speed)
        : base(date, duration)
    {
        _speed = speed;
    }

    public override double GetDistance() => _speed * (_duration / 60.0);

    public override double GetSpeed() => _speed;

    public override double GetPace() => 60.0 / _speed;

    protected override string GetDistanceUnit()
    {
        return "mile"; // still using miles, but this can be changed if needed
    }
}
