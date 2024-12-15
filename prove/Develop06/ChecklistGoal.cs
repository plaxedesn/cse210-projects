public class ChecklistGoal : Goal
{
    public int TargetCount { get; set; }
    public int CurrentCount { get; private set; }
    private const int Bonus = 500;

    public ChecklistGoal(string name, int points, int targetCount) : base(name, points)
    {
        TargetCount = targetCount;
        CurrentCount = 0;
    }

    public override int RecordEvent()
    {
        CurrentCount++;
        int totalPoints = Points;

        if (CurrentCount == TargetCount)
        {
            totalPoints += Bonus;
            MarkComplete();
        }

        return totalPoints;
    }

    public override string DisplayStatus()
    {
        return $"{base.DisplayStatus()} (Completed {CurrentCount}/{TargetCount} times)";
    }
}
