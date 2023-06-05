using System;
using System.Collections.Generic;

namespace PracticaJosueVargas.Models
{
    public partial class ConstructionStatus
    {
        public ConstructionStatus()
        {
            Projects = new HashSet<Project>();
        }

        public int ConstructionStatusId { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool? Active { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
