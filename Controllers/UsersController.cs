using Microsoft.AspNetCore.Mvc;
using KindergartenApp.Api.Models;

namespace KindergartenApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        // Pentru testare fără DB: listă statică
        private static List<User> users = new List<User>
        {
            new User { UserID = 1, FullName = "Alice Smith", Email = "alice@example.com", Role = "parent" },
            new User { UserID = 2, FullName = "John Doe", Email = "john@example.com", Role = "educator" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = users.FirstOrDefault(u => u.UserID == id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public ActionResult<User> CreateUser(User newUser)
        {
            newUser.UserID = users.Max(u => u.UserID) + 1;
            users.Add(newUser);
            return CreatedAtAction(nameof(GetUserById), new { id = newUser.UserID }, newUser);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, User updatedUser)
        {
            var user = users.FirstOrDefault(u => u.UserID == id);
            if (user == null)
                return NotFound();

            user.FullName = updatedUser.FullName;
            user.Email = updatedUser.Email;
            user.Role = updatedUser.Role;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var user = users.FirstOrDefault(u => u.UserID == id);
            if (user == null)
                return NotFound();

            users.Remove(user);
            return NoContent();
        }
    }
}
