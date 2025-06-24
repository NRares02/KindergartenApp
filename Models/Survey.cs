using System;
using System.Collections.Generic;

namespace KindergartenApp.Api.Models
{
    public class Survey
    {
        public int SurveyID { get; set; }
        public string Title { get; set; } = string.Empty;

        public int CreatedBy { get; set; }
        public User? Creator { get; set; }

        public int GroupID { get; set; }
        public Group? Group { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<SurveyQuestion>? Questions { get; set; }
    }
}
