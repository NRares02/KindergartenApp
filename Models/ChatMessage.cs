using System;

namespace KindergartenApp.Api.Models
{
    public class ChatMessage
    {
        public int ChatID { get; set; }

        public int SenderID { get; set; }
        public User? Sender { get; set; }

        public int ReceiverID { get; set; }
        public User? Receiver { get; set; }

        public string MessageText { get; set; } = string.Empty;
        public DateTime SentAt { get; set; }
        public bool IsRead { get; set; }
    }
}
