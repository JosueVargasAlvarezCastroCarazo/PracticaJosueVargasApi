using PracticaJosueVargas.Models;
using System;
using System.Collections.Generic;

namespace PracticaJosueVargas.ModelsDTOs
{
    public class LocationDTO
    {
        public LocationDTO()
        {
        }

        public LocationDTO(int locationId, string? name, string? description, bool? active)
        {
            LocationId = locationId;
            Name = name;
            Description = description;
            Active = active;
        }

        public LocationDTO(Location nativeModel)
        {
            LocationId = nativeModel.LocationId;
            Name = nativeModel.Name;
            Description = nativeModel.Description;
            Active = nativeModel.Active;
        }

        public Location getNativeModel()
        {
            Location nativeModel = new Location();
            nativeModel.LocationId = LocationId;
            nativeModel.Name = Name;
            nativeModel.Description = Description;
            nativeModel.Active = Active;
            return nativeModel;
        }



        public int LocationId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? Active { get; set; }
    }
}
