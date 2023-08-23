using System;
using System.Collections.Generic;

namespace ProjectManagementPRN221.Models
{
    public partial class Team
    {
        public Team()
        {
            Projects = new HashSet<Project>();
            Mssvs = new HashSet<Student>();
        }

        public int TeamId { get; set; }
        public string TeamName { get; set; } = null!;
        public byte? NumberOfMember { get; set; }
        public string? Leader { get; set; }

        public virtual Student? LeaderNavigation { get; set; }
        public virtual ICollection<Project> Projects { get; set; }

        public virtual ICollection<Student> Mssvs { get; set; }
    }
}
