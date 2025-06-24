using Microsoft.AspNetCore.Mvc;
using KindergartenApp.Api.Models;

namespace KindergartenApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatMessagesController : ControllerBase
    {
        private static List<ChatMessage> messages = new List<ChatMessage>
        {
            new ChatMessage
            {
                ChatMessageID = 1,
                SenderID = 1,
                Message = "Bună dimineața tuturor!",
                SentAt = DateTime.Now.AddMinutes(-15)
            },
            new ChatMessage
            {
                ChatMessageID = 2,
                SenderID = 2,
                Message = "Astăzi ieșim în parc la ora 10.",
                SentAt = DateTime.Now.AddMinutes(-10)
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<ChatMessage>> GetAll()
        {
            return Ok(messages.OrderBy(m => m.SentAt));
        }

        [HttpPost]
        public ActionResult<ChatMessage> Create(ChatMessage newMsg)
        {
            newMsg.ChatMessageID = messages.Any() ? messages.Max(m => m.ChatMessageID) + 1 : 1;
            newMsg.SentAt = DateTime.Now;
            messages.Add(newMsg);
            return CreatedAtAction(nameof(GetAll), new { id = newMsg.ChatMessageID }, newMsg);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var msg = messages.FirstOrDefault(m => m.ChatMessageID == id);
            if (msg == null)
                return NotFound();

            messages.Remove(msg);
            return NoContent();
        }
    }
}
