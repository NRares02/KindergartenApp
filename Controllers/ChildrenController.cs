using Microsoft.AspNetCore.Mvc;
using KindergartenApp.Api.Models;

namespace KindergartenApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChildrenController : ControllerBase
    {
        private static List<Child> children = new List<Child>
        {
            new Child { ChildID = 1, FullName = "Emma Popescu", DateOfBirth = new DateTime(2019, 5, 12), GroupID = 1 },
            new Child { ChildID = 2, FullName = "Luca Ionescu", DateOfBirth = new DateTime(2020, 2, 18), GroupID = 2 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Child>> GetAllChildren()
        {
            return Ok(children);
        }

        [HttpGet("{id}")]
        public ActionResult<Child> GetChildById(int id)
        {
            var child = children.FirstOrDefault(c => c.ChildID == id);
            if (child == null)
                return NotFound();

            return Ok(child);
        }

        [HttpPost]
        public ActionResult<Child> CreateChild(Child newChild)
        {
            newChild.ChildID = children.Max(c => c.ChildID) + 1;
            children.Add(newChild);
            return CreatedAtAction(nameof(GetChildById), new { id = newChild.ChildID }, newChild);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateChild(int id, Child updatedChild)
        {
            var child = children.FirstOrDefault(c => c.ChildID == id);
            if (child == null)
                return NotFound();

            child.FullName = updatedChild.FullName;
            child.DateOfBirth = updatedChild.DateOfBirth;
            child.GroupID = updatedChild.GroupID;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteChild(int id)
        {
            var child = children.FirstOrDefault(c => c.ChildID == id);
            if (child == null)
                return NotFound();

            children.Remove(child);
            return NoContent();
        }
    }
}
