using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning02 World!");

        Job job1 = new Job();
        job1._JobTitle = "Software Developer";
        job1._Company = "Econet";
        job1.StartYeartartYear = 2014;
        job1.EndYear = 2022;

        job1 job2 = new job1();
        job2._JobTitle = "Software Engineer";
        job2._Company = "Netone";
        job2._StartYear = 2023;
        job2._EndYear = 2024;

        Resume myResume = myResume ();
        myResume.Name = "Plaxedes Ncube";

        myResume.Jobs.Add(job1);
        myResume.Jobs.Add(job2);

        myResume.Display();
    }
}

class Job
{
    public string JobTitle { get;set; }
    public string Company {get; set;}
    public int StartYear { get; set; }
    public int EndYear { get; set;}
}
class Resume
{
    public string Name { get; set; }
    public List<Job> Jobs { get; set; }

    public Resume()
    {
        Jobs = new List<Job>();
    }

    public void Display()
    {
        Console.WriteLine($"Resume of {Name}");
        foreach (var job in Jobs)
        {
            Console.WriteLine($"{job.JobTitle} at {job.Company} ({job.StartYear} - {job.EndYear})");
        }
    }
}