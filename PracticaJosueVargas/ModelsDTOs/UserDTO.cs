using PracticaJosueVargas.Models;
using System;
using System.Collections.Generic;

namespace PracticaJosueVargas.ModelsDTOs
{
    public class UserDTO
    {
        public UserDTO()
        {
          
        }

        public UserDTO(int userId, string? identification, string? email, string? name, string? phoneNumber, string? address, string? password, bool? active, int userRolId, string? rolName)
        {
            UserId = userId;
            Identification = identification;
            Email = email;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            Password = password;
            Active = active;
            UserRolId = userRolId;
            RolName = rolName;
        }

        public UserDTO(int userId, string? identification, string? email, string? name, string? phoneNumber, string? address, string? password, bool? active, int userRolId)
        {
            UserId = userId;
            Identification = identification;
            Email = email;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            Password = password;
            Active = active;
            UserRolId = userRolId;
           
        }

        public UserDTO(User nativeModel)
        {
            UserId = nativeModel.UserId;
            Identification = nativeModel.Identification;
            Email = nativeModel.Email;
            Name = nativeModel.Name;
            PhoneNumber = nativeModel.PhoneNumber;
            Address = nativeModel.Address;
            Password = nativeModel.Password;
            Active = nativeModel.Active;
            UserRolId = nativeModel.UserRolId;
        }

        public User getNativeModel()
        {
            User nativeModel = new User();
            nativeModel.UserId = UserId;
            nativeModel.Identification = Identification;
            nativeModel.Email = Email;
            nativeModel.Name = Name;
            nativeModel.PhoneNumber = PhoneNumber;
            nativeModel.Address = Address;
            nativeModel.Password = Password;
            nativeModel.Active = Active;
            nativeModel.UserRolId = UserRolId;
            return nativeModel;
        }

        public int UserId { get; set; }
        public string? Identification { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Password { get; set; }
        public bool? Active { get; set; }
        public int UserRolId { get; set; }

        public string? RolName { get; set; }

    }
}
