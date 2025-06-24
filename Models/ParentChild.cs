namespace KindergartenApp.Api.Models
{
    public class ParentChild
    {
        public int ParentID { get; set; }
        public User? Parent { get; set; }

        public int ChildID { get; set; }
        public Child? Child { get; set; }
    }
}
