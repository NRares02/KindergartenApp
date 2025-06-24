using System;

namespace KindergartenApp.Api.Models
{
    public class Activity
    {
        public int ActivityID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }

        public int GroupID { get; set; }
        public Group? Group { get; set; }

        public int CreatedBy { get; set; }
        public User? Creator { get; set; }
    }
}
