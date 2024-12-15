using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class User
{
    public string Username { get; set; }
    public List<Goal> Goals { get; set; }
    public int TotalPoints { get; set; }

    public User(string username)
    {
        Username = username;
        Goals = new List<Goal>();
        TotalPoints = 0;
    }

    public void CreateGoal(string goalType, string name, int points, int targetCount = 0)
    {
        Goal goal = goalType.ToLower() switch
        {
            "simple" => new SimpleGoal(name, points),
            "eternal" => new EternalGoal(name, points),
            "checklist" => new ChecklistGoal(name, points, targetCount),
            _ => throw new ArgumentException("Invalid goal type")
        };

        Goals.Add(goal);
    }

    public void RecordEvent(string goalName)
    {
        foreach (var goal in Goals)
        {
            if (goal.Name == goalName)
            {
                TotalPoints += goal.RecordEvent();
                return;
            }
        }
    }

    public void DisplayGoals()
    {
        foreach (var goal in Goals)
        {
            Console.WriteLine(goal.DisplayStatus());
        }
    }

    public void SaveProgress()
    {
        var json = JsonConvert.SerializeObject(this);
        File.WriteAllText($"{Username}_goals.json", json);
    }

    public void LoadProgress()
    {
        var json = File.ReadAllText($"{Username}_goals.json");
        var user = JsonConvert.DeserializeObject<User>(json);
        Username = user.Username;
        Goals = user.Goals;
        TotalPoints = user.TotalPoints;
    }
}
