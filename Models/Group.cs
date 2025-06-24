using System.Collections.Generic;

namespace KindergartenApp.Api.Models
{
    public class Group
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; } = string.Empty;
        public int ClassID { get; set; }

        // Navigation
        public Class? Class { get; set; }
        public ICollection<Child>? Children { get; set; }
        public ICollection<EducatorGroup>? EducatorGroups { get; set; }
        public ICollection<Activity>? Activities { get; set; }
    }
}
