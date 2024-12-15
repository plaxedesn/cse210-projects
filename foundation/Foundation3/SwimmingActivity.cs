public class SwimmingActivity : Activity
{
    private int _laps; 

    public SwimmingActivity(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance() => (_laps * 50) / 1000.0; 

    public override double GetSpeed() => (GetDistance() / base.GetMinutes()) * 60; 

    public override double GetPace() => base.GetDistance() == 0 ? 0 : base.GetMinutes() / GetDistance(); // Pace in min/km
}
