using System;

namespace SharksApi.Models
{
    public class Post
    {
        public Guid Id { get; set; } // Unique identifier
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }

        // Constructor
        public Post(string title, string content)
        {
            Id = Guid.NewGuid();
            Title = title;
            Content = content;
            Timestamp = DateTime.UtcNow;
        }
    }
}
