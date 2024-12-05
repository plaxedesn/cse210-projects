using System;
using System.Collections.Generic;

public class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public List<Comment> GetComments()
    {
        return comments;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // video creation and set up
        Video video1 = new Video("Understanding C# principles", "Dr Dorothy", 100);
        video1.AddComment(new Comment("Laiza", "I like your tutorial."));
        video1.AddComment(new Comment("Agnes", "A great tutorial, thanks!"));
        video1.AddComment(new Comment("Beeby", "An engaging tutorial."));
        videos.Add(video1);

        Video video2 = new Video("SRP Principles Explained", "Elder Jayden", 150);
        video2.AddComment(new Comment("Doug", "Awesome explanation!"));
        video2.AddComment(new Comment("Eva", "I like the examples."));
        videos.Add(video2);

        Video video3 = new Video("C# for Beginners", "Sr Maggie", 200);
        video3.AddComment(new Comment("Nonny", "I like your tutorial."));
        video3.AddComment(new Comment("Yanda", "Great tutorial"));
        video3.AddComment(new Comment("Bongie", "Well explained."));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}