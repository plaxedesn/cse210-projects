using System;

public class Program
{
    public static void Main()
    {
        var user = new User("PlaxNcube");
        user.CreateGoal("simple", "Run a Marathon", 100);
        user.CreateGoal("eternal", "Read Scriptures", 50);
        user.CreateGoal("checklist", "Attend Temple", 50, targetCount: 10);

        user.RecordEvent("Run a Marathon");
        user.RecordEvent("Read Scriptures");
        user.RecordEvent("Attend Temple");
        user.RecordEvent("Attend Temple");

        user.DisplayGoals();
        Console.WriteLine($"Total Points: {user.TotalPoints}");
    }
}
