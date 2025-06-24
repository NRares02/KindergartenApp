using Microsoft.AspNetCore.Mvc;
using KindergartenApp.Api.Models;

namespace KindergartenApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupsController : ControllerBase
    {
        private static List<Group> groups = new List<Group>
        {
            new Group { GroupID = 1, GroupName = "Grupa Mijlocie", ClassID = 1 },
            new Group { GroupID = 2, GroupName = "Grupa Mare", ClassID = 2 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Group>> GetAllGroups()
        {
            return Ok(groups);
        }

        [HttpGet("{id}")]
        public ActionResult<Group> GetGroupById(int id)
        {
            var group = groups.FirstOrDefault(g => g.GroupID == id);
            if (group == null)
                return NotFound();

            return Ok(group);
        }

        [HttpPost]
        public ActionResult<Group> CreateGroup(Group newGroup)
        {
            newGroup.GroupID = groups.Max(g => g.GroupID) + 1;
            groups.Add(newGroup);
            return CreatedAtAction(nameof(GetGroupById), new { id = newGroup.GroupID }, newGroup);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateGroup(int id, Group updatedGroup)
        {
            var group = groups.FirstOrDefault(g => g.GroupID == id);
            if (group == null)
                return NotFound();

            group.GroupName = updatedGroup.GroupName;
            group.ClassID = updatedGroup.ClassID;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteGroup(int id)
        {
            var group = groups.FirstOrDefault(g => g.GroupID == id);
            if (group == null)
                return NotFound();

            groups.Remove(group);
            return NoContent();
        }
    }
}
