using System;
using System.Collections.Generic;

namespace PracticaJosueVargas.Models
{
    public partial class UserConstruction
    {
        public int UserConstructionId { get; set; }
        public int UserId { get; set; }
        public int ConstructionId { get; set; }

        public virtual Project Construction { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
