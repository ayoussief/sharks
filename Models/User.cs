using System;
using System.Collections.Generic;

namespace SharksApi.Models
{
    public class User
    {
        public Guid Id { get; set; } // Unique identifier
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<string> Followers { get; set; }
        public List<string> Follows { get; set; }
        public List<string> Subscribers { get; set; }
        public List<string> SubscribedTo { get; set; }
        public List<Notification> Notifications { get; set; }
        public List<string> Messages { get; set; }
        public List<string> Comments { get; set; } // Added comments
        public decimal Balance { get; set; }
        public string ProfilePic { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> Transactions { get; set; }
        public List<string> Stocks { get; set; }
        public decimal SubscriptionFee { get; set; }
        public decimal Earnings { get; set; }
        public List<string> Tasks { get; set; }
        public List<string> Rewards { get; set; }
        public List<string> Referrals { get; set; }
        public List<Post> Posts { get; set; }
        public string StreamKey { get; set; }
        public bool IsLive { get; set; }
        public string Role { get; set; } // Added role (e.g., Admin, User, etc.)
        public bool VipStatus { get; set; } // Added VIP status
        public string Plan { get; set; } // Added plan (e.g., Basic, Pro, Premium)

        // Constructor
        public User(
            string firstName,
            string lastName,
            string username,
            string email,
            string role = "User",
            bool vipStatus = false,
            string plan = "Basic",
            decimal balance = 0.0m,
            string profilePic = "",
            string phoneNumber = "",
            decimal subscriptionFee = 0.0m,
            decimal earnings = 0.0m,
            string? streamKey = null)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            Role = role;
            VipStatus = vipStatus;
            Plan = plan;
            Balance = balance;
            ProfilePic = profilePic;
            PhoneNumber = phoneNumber;
            SubscriptionFee = subscriptionFee;
            Earnings = earnings;
            StreamKey = streamKey ?? Guid.NewGuid().ToString("N"); // Generate a unique StreamKey if not provided
            IsLive = false; // Default to not live

            Followers = new List<string>();
            Follows = new List<string>();
            Subscribers = new List<string>();
            SubscribedTo = new List<string>();
            Notifications = new List<Notification>();
            Messages = new List<string>();
            Comments = new List<string>(); // Initialize comments list
            Transactions = new List<string>();
            Stocks = new List<string>();
            Tasks = new List<string>();
            Rewards = new List<string>();
            Referrals = new List<string>();
            Posts = new List<Post>();
        }



        // Functions

        // Upgrade to VIP
        public void UpgradeToVip()
        {
            VipStatus = true;
        }

        // Downgrade from VIP
        public void DowngradeFromVip()
        {
            VipStatus = false;
        }

        // Change user plan
        public void ChangePlan(string newPlan)
        {
            Plan = newPlan;
        }

        // Add a follower
        public void AddFollower(string followerId)
        {
            if (!Followers.Contains(followerId))
            {
                Followers.Add(followerId);
            }
        }

        // Remove a follower
        public void RemoveFollower(string followerId)
        {
            Followers.Remove(followerId);
        }

        // Follow another user
        public void FollowUser(string userId)
        {
            if (!Follows.Contains(userId))
            {
                Follows.Add(userId);
            }
        }

        // Unfollow another user
        public void UnfollowUser(string userId)
        {
            Follows.Remove(userId);
        }

         // Add a notification
        public void AddNotification(string title, string message)
        {
            var notification = new Notification(title, message);
            Notifications.Add(notification);
        }

        // Mark all notifications as read
        public void MarkAllNotificationsAsRead()
        {
            foreach (var notification in Notifications)
            {
                notification.MarkAsRead();
            }
        }

        // Clear all notifications
        public void ClearNotifications()
        {
            Notifications.Clear();
        }

        // Send a message
        public void SendMessage(string message)
        {
            Messages.Add(message);
        }

        // Update balance
        public void UpdateBalance(decimal amount)
        {
            Balance += amount;
        }

        // Add transaction
        public void AddTransaction(string transaction)
        {
            Transactions.Add(transaction);
        }

        // Add stock
        public void AddStock(string stockId)
        {
            if (!Stocks.Contains(stockId))
            {
                Stocks.Add(stockId);
            }
        }

        // Remove stock
        public void RemoveStock(string stockId)
        {
            Stocks.Remove(stockId);
        }

        // Add referral
        public void AddReferral(string referralId)
        {
            Referrals.Add(referralId);
        }

        // Add reward
        public void AddReward(string reward)
        {
            Rewards.Add(reward);
        }

        // Assign task
        public void AddTask(string task)
        {
            Tasks.Add(task);
        }

        // Mark task as complete
        public void CompleteTask(string task)
        {
            if (Tasks.Contains(task))
            {
                Tasks.Remove(task);
                AddReward($"Completed Task: {task}");
            }
        }

        // Add a new post
        public void AddPost(string content, string title)
        {
            Posts.Add(new Post(title, content));
        }

        // Add a comment
        public void AddComment(string comment)
        {
            Comments.Add(comment);
        }

        // Go live
        public void GoLive()
        {
            IsLive = true;
        }

        // End live stream
        public void EndLive()
        {
            IsLive = false;
        }
    }
}
