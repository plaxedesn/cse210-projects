using System;
using System.Collections.Generic;

public class Reflection : Mindfulness
{
    private static readonly List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something selfless."
    };

    private static readonly List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public override void Start()
    {
        base.Start();
        Console.WriteLine("This activity is ideal for reflecting lifetime moments such as your strength and resilience.");
        SetDuration();
        Console.WriteLine("Try again");
        Pause(3);
        Reflect();
    }

    private void Reflect()
    {
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine(prompt);

        while (DateTime.Now < endTime)
        {
            string question = questions[random.Next(questions.Count)];
            Console.WriteLine(question);
            Pause(4);
        }
        Finish();
    }
}