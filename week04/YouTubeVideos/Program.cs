using System;

class Program
{
    static void Main(string[] args)
    {
         // Create Video instances
        Video video1 = new Video("Introduction to  web development", "John Doe", 300);
        Video video2 = new Video("Advanced  Techniques in Sugar crafting", "Jane Smith", 600);
        Video video3 = new Video("MySQL  for Data Science", "Emily Brown", 900);
         Video video4 = new Video("Culinary skills for beginner ", "Emiola Sarah", 200);
       

        // Add comments to video1
        video1.AddComment(new Comment("Alice", "Great introduction!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "I love learning  Web development!"));

        // Add comments to video2
        video2.AddComment(new Comment("Dave", "Fantastic techniques!"));
        video2.AddComment(new Comment("Eve", "Can't wait to try these out."));
        video2.AddComment(new Comment("Frank", "Mind-blowing material!"));

        // Add comments to video3
        video3.AddComment(new Comment("Grace", "Perfect for beginners."));
        video3.AddComment(new Comment("Heidi", "Clear and concise."));
        video3.AddComment(new Comment("Ivan", "Highly recommended!"));

              // Add comments to video3
        video4.AddComment(new Comment("Grace", "Perfect recipe for me."));
        video4.AddComment(new Comment("Heidi", "Clear, precise  and concise."));
        video4.AddComment(new Comment("Ivan", "Highly recommended for beginners!"));
        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        // Iterate through videos and display their details
        foreach (var video in videos)
        {
            video.DisplayInfo();
        }
    }

    }
