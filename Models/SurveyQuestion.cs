using System.Collections.Generic;

namespace KindergartenApp.Api.Models
{
    public class SurveyQuestion
    {
        public int QuestionID { get; set; }
        public int SurveyID { get; set; }
        public Survey? Survey { get; set; }

        public string QuestionText { get; set; } = string.Empty;
        public string QuestionType { get; set; } = "single"; // 'single', 'multiple', 'text'

        public ICollection<SurveyAnswer>? Answers { get; set; }
    }
}
