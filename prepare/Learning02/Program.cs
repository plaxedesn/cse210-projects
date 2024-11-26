using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning02 World!");

        Job job1 = new Job
        {
            JobTitle = "Software Developer",
            Company = "Econet",
            StartYear = 2014,
            EndYear = 2022
        };

        Job job2 = new Job
        {
            JobTitle = "Software Engineer",
            Company = "Netone",
            StartYear = 2023,
            EndYear = 2024
        };

        Resume myResume = new Resume
        {
            Name = "Plaxedes Ncube"
        };

        myResume.Jobs.Add(job1);
        myResume.Jobs.Add(job2);

        myResume.Display();
    }
}

class Job
{
    public string JobTitle { get; set; }
    public string Company { get; set; }
    public int StartYear { get; set; }
    public int EndYear { get; set; }
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