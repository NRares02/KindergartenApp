using Microsoft.AspNetCore.Mvc;
using KindergartenApp.Api.Models;

namespace KindergartenApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DailyReportsController : ControllerBase
    {
        private static List<DailyReport> dailyReports = new List<DailyReport>
        {
            new DailyReport
            {
                DailyReportID = 1,
                ChildID = 1,
                ReportDate = DateTime.Today,
                Meals = "Breakfast, Lunch",
                NapTime = "13:00 - 15:00",
                Activities = "Drawing, Singing",
                Notes = "Very active and happy."
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<DailyReport>> GetAll()
        {
            return Ok(dailyReports);
        }

        [HttpGet("{id}")]
        public ActionResult<DailyReport> GetById(int id)
        {
            var report = dailyReports.FirstOrDefault(d => d.DailyReportID == id);
            if (report == null)
                return NotFound();

            return Ok(report);
        }

        [HttpPost]
        public ActionResult<DailyReport> Create(DailyReport report)
        {
            report.DailyReportID = dailyReports.Max(r => r.DailyReportID) + 1;
            dailyReports.Add(report);
            return CreatedAtAction(nameof(GetById), new { id = report.DailyReportID }, report);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, DailyReport updated)
        {
            var report = dailyReports.FirstOrDefault(r => r.DailyReportID == id);
            if (report == null)
                return NotFound();

            report.ChildID = updated.ChildID;
            report.ReportDate = updated.ReportDate;
            report.Meals = updated.Meals;
            report.NapTime = updated.NapTime;
            report.Activities = updated.Activities;
            report.Notes = updated.Notes;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var report = dailyReports.FirstOrDefault(r => r.DailyReportID == id);
            if (report == null)
                return NotFound();

            dailyReports.Remove(report);
            return NoContent();
        }
    }
}
