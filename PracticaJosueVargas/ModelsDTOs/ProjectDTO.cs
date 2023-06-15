using PracticaJosueVargas.Models;
using System;
using System.Collections.Generic;

namespace PracticaJosueVargas.ModelsDTOs
{
    public class ProjectDTO
    {
        public ProjectDTO()
        {
           
        }

        public ProjectDTO(int projectId, string? name, string? description, bool? active, int constructionStatusId, int userId, string? constructionStatusName)
        {
            ProjectId = projectId;
            Name = name;
            Description = description;
            Active = active;
            ConstructionStatusId = constructionStatusId;
            UserId = userId;
            ConstructionStatusName = constructionStatusName;
        }

        public ProjectDTO(Project nativeModel)
        {
            ProjectId = nativeModel.ProjectId;
            Name = nativeModel.Name;
            Description = nativeModel.Description;
            Active = nativeModel.Active;
            ConstructionStatusId = nativeModel.ConstructionStatusId;
            UserId = nativeModel.UserId;
        }

        public Project getNativeModel()
        {
            Project nativeModel = new Project();
            nativeModel.ProjectId = ProjectId;
            nativeModel.Name = Name;
            nativeModel.Description = Description;
            nativeModel.Active = Active;
            nativeModel.ConstructionStatusId = ConstructionStatusId;
            nativeModel.UserId = UserId;
            return nativeModel;
        }

        public int ProjectId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? Active { get; set; }
        public int ConstructionStatusId { get; set; }
        public int UserId { get; set; }

        public string? ConstructionStatusName { get; set; }

        public UserDTO? User { get; set; }
    }
}
