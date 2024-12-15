public abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; set; }
    public bool IsComplete { get; set; }

    public Goal(string name, int points)
    {
        Name = name;
        Points = points;
        IsComplete = false;
    }

    public void MarkComplete()
    {
        IsComplete = true;
    }

    public abstract int RecordEvent();

    public virtual string DisplayStatus()
    {
        return $"{(IsComplete ? "[X]" : "[ ]")} {Name}";
    }
}
