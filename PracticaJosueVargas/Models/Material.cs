using System;
using System.Collections.Generic;

namespace PracticaJosueVargas.Models
{
    public partial class Material
    {
        public int MaterialId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Notes { get; set; } = null!;
        public int Amount { get; set; }
        public bool? Active { get; set; }
        public int ProjectId { get; set; }
        public int LocationId { get; set; }

        public virtual Location Location { get; set; } = null!;
        public virtual Project Project { get; set; } = null!;
    }
}
