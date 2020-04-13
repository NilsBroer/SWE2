using PicDB.Models;
using System;
using System.Collections.Generic;

namespace PicDB
{
    sealed partial class BusinessLayer
    {
        public static PhotographerModel GetPhotographer(int id)
        {
            return DataAccessLayer.GetPhotographer(id);
        }
        public static List<string> GetAllPhotographerNames()
        {
            List<PhotographerModel> photographerList = DataAccessLayer.GetAllPhotographers();
            List<String> photographerNames = new List<string>();

            foreach (var photographer in photographerList)
            {
                photographerNames.Add(photographer.Name + " " + photographer.Surname);
            }

            return photographerNames;
        }
    }
}
