using System.Collections.Generic;

namespace KindergartenApp.Api.Models
{
    public class Class
    {
        public int ClassID { get; set; }
        public string ClassName { get; set; } = string.Empty;

        // Navigation
        public ICollection<Group>? Groups { get; set; }
    }
}
