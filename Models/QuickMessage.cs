using System;

namespace KindergartenApp.Api.Models
{
    public class QuickMessage
    {
        public int MessageID { get; set; }

        public int SenderID { get; set; }
        public User? Sender { get; set; }

        public int GroupID { get; set; }
        public Group? Group { get; set; }

        public string MessageText { get; set; } = string.Empty;
        public DateTime SentAt { get; set; }
    }
}
