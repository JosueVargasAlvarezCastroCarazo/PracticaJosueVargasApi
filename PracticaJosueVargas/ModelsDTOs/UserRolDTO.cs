using PracticaJosueVargas.Models;
using System;
using System.Collections.Generic;

namespace PracticaJosueVargas.ModelsDTOs
{
    public class UserRolDTO
    {
        public UserRolDTO()
        {
        }

        public UserRolDTO(int userRolId, string? name, string? description, bool? active)
        {
            UserRolId = userRolId;
            Name = name;
            Description = description;
            Active = active;
        }

        public UserRolDTO(UserRol nativeModel)
        {
            UserRolId = nativeModel.UserRolId;
            Name = nativeModel.Name;
            Description = nativeModel.Description;
            Active = nativeModel.Active;
        }

        public UserRol getNativeModel()
        {
            UserRol nativeModel = new UserRol();
            nativeModel.UserRolId = UserRolId;
            nativeModel.Name = Name;
            nativeModel.Description = Description;
            nativeModel.Active = Active;
            return nativeModel;
        }

        public int UserRolId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? Active { get; set; }
    }
}
