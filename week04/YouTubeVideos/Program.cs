using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();
        Video video1 = new Video(
            "How to Learn C# in 30 Days",
            "CodeMaster",
            1800);
        video1.AddComment(new Comment("Ivan", "Great explanation!"));
        video1.AddComment(new Comment("Maria", "This helped me a lot."));
        video1.AddComment(new Comment("John", "Very easy to follow."));
        videos.Add(video1);
        Video video2 = new Video(
            "Top 10 Anime of All Time",
            "AnimeWorld",
            900);
        video2.AddComment(new Comment("Alex", "Attack on Titan should be #1!"));
        video2.AddComment(new Comment("Sarah", "Nice list."));
        video2.AddComment(new Comment("Luis", "I disagree with some rankings."));
        videos.Add(video2);
        Video video3 = new Video(
            "Building a Fantasy World",
            "StoryCraft",
            1500);
        video3.AddComment(new Comment("Emma", "Amazing worldbuilding tips."));
        video3.AddComment(new Comment("Carlos", "This inspired my story."));
        video3.AddComment(new Comment("Sofia", "Excellent content."));
        videos.Add(video3);
        Video video4 = new Video(
            "Beginner Workout Routine",
            "FitLife",
            1200);
        video4.AddComment(new Comment("Mike", "Starting this today."));
        video4.AddComment(new Comment("Anna", "Very motivating."));
        video4.AddComment(new Comment("David", "Thanks for sharing."));
        videos.Add(video4);
        foreach (Video video in videos)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Comments: {video.GetCommentCount()}");
            Console.WriteLine();
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"{comment.GetName()}: {comment.GetText()}");
            }
            Console.WriteLine();
        }
    }
}