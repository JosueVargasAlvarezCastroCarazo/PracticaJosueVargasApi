using PracticaJosueVargas.Models;
using System;
using System.Collections.Generic;

namespace PracticaJosueVargas.ModelsDTOs
{
    public class MaterialDTO
    {
        public MaterialDTO()
        {
        }

        public MaterialDTO(int materialId, string? name, string? description, string? notes, int amount, bool? active, int projectId, int locationId, string? locationName)
        {
            MaterialId = materialId;
            Name = name;
            Description = description;
            Notes = notes;
            Amount = amount;
            Active = active;
            ProjectId = projectId;
            LocationId = locationId;
            LocationName = locationName;
        }

        public MaterialDTO(Material nativeModel)
        {
            MaterialId = nativeModel.MaterialId;
            Name = nativeModel.Name;
            Description = nativeModel.Description;
            Notes = nativeModel.Notes;
            Amount = nativeModel.Amount;
            Active = nativeModel.Active;
            ProjectId = nativeModel.ProjectId;
            LocationId = nativeModel.LocationId;
        }

        public Material getNativeModel()
        {
            Material nativeModel = new Material();
            nativeModel.MaterialId = MaterialId;
            nativeModel.Name = Name;
            nativeModel.Description = Description;
            nativeModel.Notes = Notes;
            nativeModel.Amount = Amount;
            nativeModel.Active = Active;
            nativeModel.ProjectId = ProjectId;
            nativeModel.LocationId = LocationId;
            return nativeModel;
        }

        public int MaterialId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Notes { get; set; }
        public int Amount { get; set; }
        public bool? Active { get; set; }
        public int ProjectId { get; set; }
        public int LocationId { get; set; }

        public string? LocationName { get; set; }

    }
}
