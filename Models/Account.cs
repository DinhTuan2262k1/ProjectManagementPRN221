using System;
using System.Collections.Generic;

namespace ProjectManagementPRN221.Models
{
    public partial class Account
    {
        public Account()
        {
            /*Students = new HashSet<Student>();*/
        }

        public int AccountId { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int? RoleId { get; set; }

        public virtual Role? Role { get; set; }
        /*public virtual ICollection<Student> Students { get; set; }*/
    }
}
