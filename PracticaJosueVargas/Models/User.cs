using System;
using System.Collections.Generic;

namespace PracticaJosueVargas.Models
{
    public partial class User
    {
        public User()
        {
            Projects = new HashSet<Project>();
            UserConstructions = new HashSet<UserConstruction>();
        }

        public int UserId { get; set; }
        public string Identification { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool? Active { get; set; }
        public int UserRolId { get; set; }

        public virtual UserRol UserRol { get; set; } = null!;
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<UserConstruction> UserConstructions { get; set; }
    }
}
