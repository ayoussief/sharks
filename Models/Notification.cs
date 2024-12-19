using System;

namespace SharksApi.Models
{
    public class Notification
    {
        public Guid Id { get; set; } // Unique identifier
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; }

        // Constructor
        public Notification(string title, string message)
        {
            Id = Guid.NewGuid();
            Title = title;
            Message = message;
            Timestamp = DateTime.UtcNow;
            IsRead = false;
        }

        // Mark the notification as read
        public void MarkAsRead()
        {
            IsRead = true;
        }
    }
}
