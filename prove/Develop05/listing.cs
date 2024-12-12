using System;
using System.Collections.Generic;

public class Listing : Mindfulness
{
    private static readonly List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public override void Start()
    {
        base.Start();
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can.");
        SetDuration();
        Console.WriteLine("Prepare to begin...");
        Pause(3);
        ListItems();
    }

    private void ListItems()
    {
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine(prompt);
        Pause(3); // Giving some time to think

        List<string> items = new List<string>();
        Console.WriteLine("Start listing your items (type 'done' when finished):");

        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            if (item.ToLower() == "done")
            {
                break;
            }
            items.Add(item);
        }

        Console.WriteLine($"You listed {items.Count} items.");
        Finish();
    }
}