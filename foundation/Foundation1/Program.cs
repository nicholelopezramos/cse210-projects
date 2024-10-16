using System;
using System.Collections.Generic;

class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }

    public override string ToString()
    {
        return $"{Name}: {Text}";
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // Length in seconds
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
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

    public override string ToString()
    {
        TimeSpan time = TimeSpan.FromSeconds(Length);
        string formattedTime = $"{time.Minutes}m {time.Seconds}s";
        return $"Title: {Title}\nAuthor: {Author}\nLength: {formattedTime}\nComments: {GetNumberOfComments()}";
    }

    public void DisplayComments()
    {
        foreach (Comment comment in comments)
        {
            Console.WriteLine($" - {comment}");
        }
    }
}

class Program
{
    static void Main()
    {
        // Create videos and add comments
        Video video1 = new Video("Mastering JavaScript", "Tech Guru", 530);
        video1.AddComment(new Comment("John", "Loved the part about closures!"));
        video1.AddComment(new Comment("Sarah", "This was so helpful, thank you!"));
        video1.AddComment(new Comment("Michael", "Could you explain arrow functions in more detail?"));

        Video video2 = new Video("Building a REST API with Node.js", "Code Wizard", 680);
        video2.AddComment(new Comment("Emily", "Great tutorial on building APIs!"));
        video2.AddComment(new Comment("Daniel", "This saved me hours of frustration!"));
        video2.AddComment(new Comment("Alex", "What about error handling?"));

        Video video3 = new Video("CSS Grid vs Flexbox", "DesignPro", 420);
        video3.AddComment(new Comment("Olivia", "Finally understood the differences!"));
        video3.AddComment(new Comment("Liam", "The visuals made it super easy to follow."));
        video3.AddComment(new Comment("Sophia", "More grid layout examples, please!"));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display videos and comments without user interaction
        foreach (Video video in videos)
        {
            Console.WriteLine(video);
            Console.WriteLine("Comments:");
            video.DisplayComments();
            Console.WriteLine(); // Separate output for each video
        }
    }
}
