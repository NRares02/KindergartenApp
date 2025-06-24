namespace KindergartenApp.Api.Models
{
    public class EducatorGroup
    {
        public int EducatorID { get; set; }
        public User? Educator { get; set; }

        public int GroupID { get; set; }
        public Group? Group { get; set; }
    }
}
