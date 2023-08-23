using System;
using System.Collections.Generic;

namespace ProjectManagementPRN221.Models
{
    public partial class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = null!;
        public string Topic { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? FinishDate { get; set; }
        public bool? IsFinished { get; set; }
        public byte? Grade { get; set; }
        public int? TeamId { get; set; }

        public virtual Team? Team { get; set; }
    }
}
