using System;

namespace KindergartenApp.Api.Models
{
    public class Media
    {
        public int MediaID { get; set; }
        public int GroupID { get; set; }
        public Group? Group { get; set; }

        public string FileURL { get; set; } = string.Empty;
        public int UploadedBy { get; set; }
        public User? Uploader { get; set; }

        public DateTime UploadDate { get; set; }
    }
}
