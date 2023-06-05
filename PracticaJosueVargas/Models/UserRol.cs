using System;
using System.Collections.Generic;

namespace PracticaJosueVargas.Models
{
    public partial class UserRol
    {
        public UserRol()
        {
            Users = new HashSet<User>();
        }

        public int UserRolId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool? Active { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
