using PicDB.Models;
using System;
using System.Collections.Generic;
using EH = PicDB.Helper.ExceptionHandling;

namespace PicDB
{
    sealed partial class BusinessLayer
    {
        public static PhotographerModel GetPhotographer(int id)
        {
            return EH.Try(() => DataAccessLayer.GetPhotographer(id));
        }

        public static List<PhotographerModel> GetAllPhotographers()
        {
            return EH.Try(DataAccessLayer.GetAllPhotographers);
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
