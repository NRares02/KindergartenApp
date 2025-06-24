using System;
using System.Collections.Generic;

namespace KindergartenApp.Api.Models
{
    public class Child
    {
        public int ChildID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public int GroupID { get; set; }

        // Navigation
        public Group? Group { get; set; }
        public ICollection<ParentChild>? Parents { get; set; }
        public ICollection<DailyReport>? Reports { get; set; }
    }
}
