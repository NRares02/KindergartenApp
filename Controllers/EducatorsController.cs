using Microsoft.AspNetCore.Mvc;
using KindergartenApp.Api.Models;

namespace KindergartenApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EducatorsController : ControllerBase
    {
        private static List<User> educators = new List<User>
        {
            new User { UserID = 1, FullName = "Andreea Popescu", Role = "Educator", Email = "andreea.popescu@example.com" },
            new User { UserID = 2, FullName = "Mihai Ionescu", Role = "Educator", Email = "mihai.ionescu@example.com" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllEducators()
        {
            var result = educators.Where(u => u.Role == "Educator").ToList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetEducatorById(int id)
        {
            var educator = educators.FirstOrDefault(u => u.UserID == id && u.Role == "Educator");
            if (educator == null)
                return NotFound();

            return Ok(educator);
        }

        [HttpPost]
        public ActionResult<User> CreateEducator(User newEducator)
        {
            newEducator.UserID = educators.Max(e => e.UserID) + 1;
            newEducator.Role = "Educator";
            educators.Add(newEducator);
            return CreatedAtAction(nameof(GetEducatorById), new { id = newEducator.UserID }, newEducator);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEducator(int id, User updatedEducator)
        {
            var educator = educators.FirstOrDefault(u => u.UserID == id && u.Role == "Educator");
            if (educator == null)
                return NotFound();

            educator.FullName = updatedEducator.FullName;
            educator.Email = updatedEducator.Email;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEducator(int id)
        {
            var educator = educators.FirstOrDefault(u => u.UserID == id && u.Role == "Educator");
            if (educator == null)
                return NotFound();

            educators.Remove(educator);
            return NoContent();
        }
    }
}
