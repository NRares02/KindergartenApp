using Microsoft.AspNetCore.Mvc;
using KindergartenApp.Api.Models;

namespace KindergartenApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivitiesController : ControllerBase
    {
        private static List<Activity> activities = new List<Activity>
        {
            new Activity { ActivityID = 1, Title = "Ziua Sportului", Description = "Activități sportive în aer liber", Date = DateTime.Today.AddDays(2), GroupID = 1 },
            new Activity { ActivityID = 2, Title = "Vizită la Zoo", Description = "Excursie cu clasa", Date = DateTime.Today.AddDays(5), GroupID = 2 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Activity>> GetAllActivities()
        {
            return Ok(activities);
        }

        [HttpGet("{id}")]
        public ActionResult<Activity> GetActivityById(int id)
        {
            var activity = activities.FirstOrDefault(a => a.ActivityID == id);
            if (activity == null)
                return NotFound();

            return Ok(activity);
        }

        [HttpPost]
        public ActionResult<Activity> CreateActivity(Activity newActivity)
        {
            newActivity.ActivityID = activities.Max(a => a.ActivityID) + 1;
            activities.Add(newActivity);
            return CreatedAtAction(nameof(GetActivityById), new { id = newActivity.ActivityID }, newActivity);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateActivity(int id, Activity updatedActivity)
        {
            var activity = activities.FirstOrDefault(a => a.ActivityID == id);
            if (activity == null)
                return NotFound();

            activity.Title = updatedActivity.Title;
            activity.Description = updatedActivity.Description;
            activity.Date = updatedActivity.Date;
            activity.GroupID = updatedActivity.GroupID;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteActivity(int id)
        {
            var activity = activities.FirstOrDefault(a => a.ActivityID == id);
            if (activity == null)
                return NotFound();

            activities.Remove(activity);
            return NoContent();
        }
    }
}
