using PracticaJosueVargas.Models;
using System;
using System.Collections.Generic;

namespace PracticaJosueVargas.ModelsDTOs
{
    public class ConstructionStatusDTO
    {
        public ConstructionStatusDTO()
        {
        }

        public ConstructionStatusDTO(int constructionStatusId, string? code, string? name, string? description, bool? active)
        {
            ConstructionStatusId = constructionStatusId;
            Code = code;
            Name = name;
            Description = description;
            Active = active;
        }

        public ConstructionStatusDTO(ConstructionStatus nativeModel)
        {
            ConstructionStatusId = nativeModel.ConstructionStatusId;
            Code = nativeModel.Code;
            Name = nativeModel.Name;
            Description = nativeModel.Description;
            Active = nativeModel.Active;
        }

        public ConstructionStatus getNativeModel()
        {
            ConstructionStatus nativeModel = new ConstructionStatus();
            nativeModel.ConstructionStatusId = ConstructionStatusId;
            nativeModel.Code = Code;
            nativeModel.Name = Name;
            nativeModel.Description = Description;
            nativeModel.Active = Active;
            return nativeModel;
        }

        public int ConstructionStatusId { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? Active { get; set; }

    }
}
