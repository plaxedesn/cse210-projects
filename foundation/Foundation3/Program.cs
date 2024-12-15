using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        
        List<Activity> activities = new List<Activity>
        {
            new RunningActivity(new DateTime(2022, 11, 3), 30, 3.0),
            new CyclingActivity(new DateTime(2022, 11, 4), 45, 12.0),
            new SwimmingActivity(new DateTime(2022, 11, 5), 30, 20)
        };

        
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
