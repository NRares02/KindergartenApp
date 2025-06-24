using Microsoft.AspNetCore.Mvc;
using KindergartenApp.Api.Models;

namespace KindergartenApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MediaController : ControllerBase
    {
        private static List<Media> mediaItems = new List<Media>
        {
            new Media
            {
                MediaID = 1,
                Title = "Outdoor Play",
                Url = "https://example.com/images/outdoor.jpg",
                UploadDate = DateTime.Now.AddDays(-2),
                UploadedBy = 1,
                ChildID = 1,
                GroupID = null
            },
            new Media
            {
                MediaID = 2,
                Title = "Drawing Time",
                Url = "https://example.com/images/drawing.jpg",
                UploadDate = DateTime.Now.AddDays(-1),
                UploadedBy = 2,
                ChildID = null,
                GroupID = 1
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Media>> GetAll()
        {
            return Ok(mediaItems);
        }

        [HttpGet("{id}")]
        public ActionResult<Media> GetById(int id)
        {
            var media = mediaItems.FirstOrDefault(m => m.MediaID == id);
            if (media == null)
                return NotFound();

            return Ok(media);
        }

        [HttpPost]
        public ActionResult<Media> Create(Media newMedia)
        {
            newMedia.MediaID = mediaItems.Max(m => m.MediaID) + 1;
            newMedia.UploadDate = DateTime.Now;
            mediaItems.Add(newMedia);
            return CreatedAtAction(nameof(GetById), new { id = newMedia.MediaID }, newMedia);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Media updatedMedia)
        {
            var media = mediaItems.FirstOrDefault(m => m.MediaID == id);
            if (media == null)
                return NotFound();

            media.Title = updatedMedia.Title;
            media.Url = updatedMedia.Url;
            media.UploadedBy = updatedMedia.UploadedBy;
            media.ChildID = updatedMedia.ChildID;
            media.GroupID = updatedMedia.GroupID;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var media = mediaItems.FirstOrDefault(m => m.MediaID == id);
            if (media == null)
                return NotFound();

            mediaItems.Remove(media);
            return NoContent();
        }
    }
}
