using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep2 World!");
        Console.Write("Give your grade percentage?");
        string answer = Console.ReadLine();
        int percent = int.Parse (answer);

        string letter = "";

        if (percent >=90)
        {
            letter = "A";
        }
        else if (percent >=80)
        {
            letter = "B";
        }
        else if (percent >=70)
        {
            letter = "C";
        }
        else if (percent >=60)
        {
            letter = "C";
        
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Grade:{letter}");

        if (percent >= 70)
        {
            Console.WriteLine("Congrats to you!");
        }
        else
        {
            Console.WriteLine("Try again next time");
        }
    }
}