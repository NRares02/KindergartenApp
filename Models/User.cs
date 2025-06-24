using System;
using System.Collections.Generic;

namespace KindergartenApp.Api.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty; // 'admin', 'educator', 'parent'
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public ICollection<ParentChild>? Children { get; set; }
        public ICollection<EducatorGroup>? EducatorGroups { get; set; }
    }
}
