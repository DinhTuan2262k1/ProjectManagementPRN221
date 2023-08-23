using System;
using System.Collections.Generic;

namespace ProjectManagementPRN221.Models
{
    public partial class Student
    {
        public Student()
        {
            TeamsNavigation = new HashSet<Team>();
            Teams = new HashSet<Team>();
        }

        public string Mssv { get; set; } = null!;
        public string StudentName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string Cmnd { get; set; } = null!;
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public int? AccountId { get; set; }

        public virtual Account? Account { get; set; }
        public virtual ICollection<Team> TeamsNavigation { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
