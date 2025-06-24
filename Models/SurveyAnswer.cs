namespace KindergartenApp.Api.Models
{
    public class SurveyAnswer
    {
        public int AnswerID { get; set; }

        public int QuestionID { get; set; }
        public SurveyQuestion? Question { get; set; }

        public int ParentID { get; set; }
        public User? Parent { get; set; }

        public string AnswerText { get; set; } = string.Empty;
    }
}
