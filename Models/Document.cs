using System;

namespace KindergartenApp.Api.Models
{
    public class Document
    {
        public int DocumentID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string FileURL { get; set; } = string.Empty;

        public int UploadedBy { get; set; }
        public User? Uploader { get; set; }

        public int GroupID { get; set; }
        public Group? Group { get; set; }

        public DateTime UploadDate { get; set; }
    }
}
