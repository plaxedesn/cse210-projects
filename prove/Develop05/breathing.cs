using System;

public class Breathing : Mindfulness
{
    public override void Start()
    {
        base.Start();
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly.");
        SetDuration();
        Console.WriteLine("Prepare to start");
        Pause(3);
        Breathe();
    }

    private void Breathe()
    {
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breathe in...");
            Pause(4);
            Console.WriteLine("Breathe out...");
            Pause(4);
        }
        Finish();
    }
}