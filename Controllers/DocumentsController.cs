using Microsoft.AspNetCore.Mvc;
using KindergartenApp.Api.Models;

namespace KindergartenApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsController : ControllerBase
    {
        private static List<Document> documents = new List<Document>
        {
            new Document
            {
                DocumentID = 1,
                Title = "Programul Săptămânii",
                Url = "https://example.com/docs/program.pdf",
                UploadDate = DateTime.Now.AddDays(-3),
                UploadedBy = 1,
                GroupID = 1
            },
            new Document
            {
                DocumentID = 2,
                Title = "Regulament Intern",
                Url = "https://example.com/docs/regulament.pdf",
                UploadDate = DateTime.Now.AddDays(-5),
                UploadedBy = 2,
                GroupID = null
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Document>> GetAll()
        {
            return Ok(documents);
        }

        [HttpGet("{id}")]
        public ActionResult<Document> GetById(int id)
        {
            var doc = documents.FirstOrDefault(d => d.DocumentID == id);
            if (doc == null)
                return NotFound();

            return Ok(doc);
        }

        [HttpPost]
        public ActionResult<Document> Create(Document newDoc)
        {
            newDoc.DocumentID = documents.Max(d => d.DocumentID) + 1;
            newDoc.UploadDate = DateTime.Now;
            documents.Add(newDoc);
            return CreatedAtAction(nameof(GetById), new { id = newDoc.DocumentID }, newDoc);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Document updated)
        {
            var doc = documents.FirstOrDefault(d => d.DocumentID == id);
            if (doc == null)
                return NotFound();

            doc.Title = updated.Title;
            doc.Url = updated.Url;
            doc.UploadedBy = updated.UploadedBy;
            doc.GroupID = updated.GroupID;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var doc = documents.FirstOrDefault(d => d.DocumentID == id);
            if (doc == null)
                return NotFound();

            documents.Remove(doc);
            return NoContent();
        }
    }
}
