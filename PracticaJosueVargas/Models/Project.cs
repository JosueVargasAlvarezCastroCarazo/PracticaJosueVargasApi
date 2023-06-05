using System;
using System.Collections.Generic;

namespace PracticaJosueVargas.Models
{
    public partial class Project
    {
        public Project()
        {
            Materials = new HashSet<Material>();
            UserConstructions = new HashSet<UserConstruction>();
        }

        public int ProjectId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool? Active { get; set; }
        public int ConstructionStatusId { get; set; }
        public int UserId { get; set; }

        public virtual ConstructionStatus ConstructionStatus { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Material> Materials { get; set; }
        public virtual ICollection<UserConstruction> UserConstructions { get; set; }
    }
}
