using System;

namespace KindergartenApp.Api.Models
{
    public class DailyReport
    {
        public int ReportID { get; set; }
        public int ChildID { get; set; }
        public Child? Child { get; set; }

        public int EducatorID { get; set; }
        public User? Educator { get; set; }

        public DateTime Date { get; set; }
        public string Sleep { get; set; } = string.Empty;
        public string Food { get; set; } = string.Empty;
        public string Mood { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }
}
