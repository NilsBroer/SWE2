using PicDB.Models;
using System;
using System.Collections.Generic;
using PicDB.ViewModels;
using EH = PicDB.Helper.ExceptionHandling;

namespace PicDB
{
    ///
    /// Photographer-Part of the BusinessLayer. Calls the DAL.
    ///
    sealed partial class BusinessLayer
    {
        ///
        /// Gets the n-th Photographer from the Database
        ///
        public static PhotographerModel GetPhotographer(int id)
        {
            return EH.Try(() => DataAccessLayer.GetPhotographer(id));
        }

        ///
        /// Returns a list of all Photographers
        ///
        public static List<PhotographerModel> GetAllPhotographers()
        {
            return EH.Try(DataAccessLayer.GetAllPhotographers);
        }

        ///
        /// Returns a String List of the names of all Photographers
        ///
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

        ///
        /// Updates a Photographer
        ///
        public static void UpdatePhotographer(PhotographerViewModel vm)
        {
            DataAccessLayer.UpdatePhotographer(vm);
        }

        ///
        /// Creates a new Photographer in the Database
        ///
        public static void CreatePhotographer(PhotographerViewModel vm)
        {
            DataAccessLayer.CreatePhotographer(vm);
        }
    }
}
