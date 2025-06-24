using Microsoft.AspNetCore.Mvc;
using KindergartenApp.Api.Models;

namespace KindergartenApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParentChildController : ControllerBase
    {
        private static List<ParentChild> parentChildRelations = new List<ParentChild>
        {
            new ParentChild { ParentChildID = 1, ParentID = 1, ChildID = 1 },
            new ParentChild { ParentChildID = 2, ParentID = 1, ChildID = 2 },
            new ParentChild { ParentChildID = 3, ParentID = 2, ChildID = 3 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<ParentChild>> GetAllRelations()
        {
            return Ok(parentChildRelations);
        }

        [HttpGet("{id}")]
        public ActionResult<ParentChild> GetRelationById(int id)
        {
            var relation = parentChildRelations.FirstOrDefault(pc => pc.ParentChildID == id);
            if (relation == null)
                return NotFound();

            return Ok(relation);
        }

        [HttpPost]
        public ActionResult<ParentChild> CreateRelation(ParentChild newRelation)
        {
            newRelation.ParentChildID = parentChildRelations.Max(pc => pc.ParentChildID) + 1;
            parentChildRelations.Add(newRelation);
            return CreatedAtAction(nameof(GetRelationById), new { id = newRelation.ParentChildID }, newRelation);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRelation(int id, ParentChild updatedRelation)
        {
            var existing = parentChildRelations.FirstOrDefault(pc => pc.ParentChildID == id);
            if (existing == null)
                return NotFound();

            existing.ParentID = updatedRelation.ParentID;
            existing.ChildID = updatedRelation.ChildID;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRelation(int id)
        {
            var existing = parentChildRelations.FirstOrDefault(pc => pc.ParentChildID == id);
            if (existing == null)
                return NotFound();

            parentChildRelations.Remove(existing);
            return NoContent();
        }
    }
}

