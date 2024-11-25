using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning02 World!");

        Job job1 = new Job();
        job1._jobTitle = "Software Developer";
        job1._company = "Econet";
        job1.startYear = 2014;
        job1.endYear = 2022;

        job1 job2 = new job1();
        job2._jobTitle = "Software Engineer";
        job2._company = "Netone";
        job2._startYear = 2023;
        job2._endYear = 2024;

        Resume myResume = myResume ();
        myResume._name = "Plaxedes Ncube";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}