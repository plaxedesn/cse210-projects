public class RunningActivity : Activity
{
    private double _distance; 

    public RunningActivity(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;

    public override double GetSpeed() => (_distance / 60) * 60; 

    public override double GetPace() => base.GetDistance() == 0 ? 0 : base.GetMinutes() / GetDistance();
}
