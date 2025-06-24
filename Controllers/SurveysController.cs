using Microsoft.AspNetCore.Mvc;
using KindergartenApp.Api.Models;

namespace KindergartenApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SurveysController : ControllerBase
    {
        private static List<Survey> surveys = new List<Survey>
        {
            new Survey
            {
                SurveyID = 1,
                Title = "Feedback activitate săptămânală",
                Description = "Spuneți-ne cum vi s-a părut activitatea din această săptămână.",
                CreatedBy = 2,
                CreatedAt = DateTime.Now.AddDays(-3),
                Questions = new List<SurveyQuestion>
                {
                    new SurveyQuestion
                    {
                        SurveyQuestionID = 1,
                        QuestionText = "Copilul dvs. a fost entuziasmat de activități?"
                    },
                    new SurveyQuestion
                    {
                        SurveyQuestionID = 2,
                        QuestionText = "Aveți sugestii pentru activități viitoare?"
                    }
                }
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Survey>> GetAllSurveys()
        {
            return Ok(surveys);
        }

        [HttpGet("{id}")]
        public ActionResult<Survey> GetSurveyById(int id)
        {
            var survey = surveys.FirstOrDefault(s => s.SurveyID == id);
            if (survey == null)
                return NotFound();
            return Ok(survey);
        }

        [HttpPost]
        public ActionResult<Survey> CreateSurvey(Survey newSurvey)
        {
            newSurvey.SurveyID = surveys.Any() ? surveys.Max(s => s.SurveyID) + 1 : 1;
            newSurvey.CreatedAt = DateTime.Now;

            foreach (var question in newSurvey.Questions)
            {
                question.SurveyQuestionID = new Random().Next(1000, 9999);
                question.SurveyID = newSurvey.SurveyID;
            }

            surveys.Add(newSurvey);
            return CreatedAtAction(nameof(GetSurveyById), new { id = newSurvey.SurveyID }, newSurvey);
        }

        [HttpPost("{surveyId}/answers")]
        public IActionResult SubmitAnswers(int surveyId, [FromBody] List<SurveyAnswer> answers)
        {
            // Doar simulare: le primim și returnăm 200 OK
            if (!surveys.Any(s => s.SurveyID == surveyId))
                return NotFound();

            return Ok(new { message = "Răspunsuri înregistrate cu succes." });
        }
    }
}
