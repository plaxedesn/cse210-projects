using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, Func<Mindfulness>> activities = new Dictionary<string, Func<Mindfulness>>
        {
            { "1", () => new Breathing() },
            { "2", () => new Reflection() },
            { "3", () => new Listing() }
        };

        while (true)
        {
            Console.WriteLine("Pick an activity to do:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            string choice = Console.ReadLine();

            if (choice == "4")
            {
                Console.WriteLine("Thank you. Goodbye!");
                break;
            }

            if (activities.TryGetValue(choice, out var activityFactory))
            {
                Mindfulness activity = activityFactory();
                activity.Start();
            }
            else
            {
                Console.WriteLine("Invalid. Try again.");
            }
        }
    }
}