public class EternalGoal : Goal
{
    public int CompletionCount { get; private set; }

    public EternalGoal(string name, int points) : base(name, points)
    {
        CompletionCount = 0;
    }

    public override int RecordEvent()
    {
        CompletionCount++;
        return Points;
    }

    public override string DisplayStatus()
    {
        return $"{base.DisplayStatus()} (Completed {CompletionCount} times)";
    }
}
