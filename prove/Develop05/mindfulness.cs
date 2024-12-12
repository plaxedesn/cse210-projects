using System;
using System.Threading;

public class Mindfulness
{
    protected int duration;

    public void SetDuration()
    {
        Console.Write("Enter your activity duration in seconds: ");
        duration = int.Parse(Console.ReadLine());
    }

    public virtual void Start()
    {
        Console.WriteLine("Starting the activity");
        Thread.Sleep(2000);
    }

    public void Finish()
    {
        Console.WriteLine("Great job! Activity completed.");
        Thread.Sleep(2000);
    }

    protected void Pause(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine($"Pausing for {i} seconds...");
            Thread.Sleep(1000);
        }
    }
}