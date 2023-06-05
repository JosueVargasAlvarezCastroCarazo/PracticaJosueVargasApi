using System;
using System.Collections.Generic;

namespace PracticaJosueVargas.Models
{
    public partial class Location
    {
        public Location()
        {
            Materials = new HashSet<Material>();
        }

        public int LocationId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool? Active { get; set; }

        public virtual ICollection<Material> Materials { get; set; }
    }
}
