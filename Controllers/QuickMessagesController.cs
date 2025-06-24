using Microsoft.AspNetCore.Mvc;
using KindergartenApp.Api.Models;

namespace KindergartenApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuickMessagesController : ControllerBase
    {
        private static List<QuickMessage> quickMessages = new List<QuickMessage>
        {
            new QuickMessage
            {
                QuickMessageID = 1,
                Content = "Va întârzia azi.",
                SentBy = 2,
                SentTo = 1,
                SentAt = DateTime.Now.AddMinutes(-20)
            },
            new QuickMessage
            {
                QuickMessageID = 2,
                Content = "A fost luat de bunici.",
                SentBy = 3,
                SentTo = 1,
                SentAt = DateTime.Now.AddMinutes(-5)
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<QuickMessage>> GetAll()
        {
            return Ok(quickMessages);
        }

        [HttpGet("{id}")]
        public ActionResult<QuickMessage> GetById(int id)
        {
            var msg = quickMessages.FirstOrDefault(q => q.QuickMessageID == id);
            if (msg == null)
                return NotFound();

            return Ok(msg);
        }

        [HttpPost]
        public ActionResult<QuickMessage> Create(QuickMessage newMsg)
        {
            newMsg.QuickMessageID = quickMessages.Max(q => q.QuickMessageID) + 1;
            newMsg.SentAt = DateTime.Now;
            quickMessages.Add(newMsg);
            return CreatedAtAction(nameof(GetById), new { id = newMsg.QuickMessageID }, newMsg);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var msg = quickMessages.FirstOrDefault(q => q.QuickMessageID == id);
            if (msg == null)
                return NotFound();

            quickMessages.Remove(msg);
            return NoContent();
        }
    }
}
