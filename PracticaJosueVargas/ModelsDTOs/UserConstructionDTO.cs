using PracticaJosueVargas.Models;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace PracticaJosueVargas.ModelsDTOs
{
    public class UserConstructionDTO
    {
        public UserConstructionDTO()
        {
        }

        public UserConstructionDTO(int userConstructionId, int userId, int constructionId)
        {
            UserConstructionId = userConstructionId;
            UserId = userId;
            ConstructionId = constructionId;
        }

        public UserConstructionDTO(UserConstruction nativeModel)
        {
            UserConstructionId = nativeModel.UserConstructionId;
            UserId = nativeModel.UserId;
            ConstructionId = nativeModel.ConstructionId;
        }

        public UserConstruction getNativeModel()
        {
            UserConstruction nativeModel = new UserConstruction();
            nativeModel.UserConstructionId = UserConstructionId;
            nativeModel.UserId = UserId;
            nativeModel.ConstructionId = ConstructionId;
            return nativeModel;
        }

        public int UserConstructionId { get; set; }
        public int UserId { get; set; }
        public int ConstructionId { get; set; }

    }
}
