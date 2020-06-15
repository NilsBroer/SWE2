using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using PicDB.ViewModels;

namespace PicDB.Models
{
    public class PhotographerModel
    {
        ///
        /// Photographer ID
        ///
        public int Id { get; set; }

        ///
        /// Name of the Photographer
        ///
        public String Name { get; set; }

        ///
        /// Surname of the Photographer
        ///
        public String Surname { get; set; }

        ///
        /// Birthday of the Photographer
        ///
        public DateTime? Birthday { get; set; }

        ///
        /// Notes
        ///
        public String Notes { get; set; }

        ///
        /// Method to Update this Entry
        ///
        public void Update(PhotographerViewModel photographer)
        {
            Id = photographer.Id;
            Name = photographer.Name;
            Surname = photographer.Surname;
            Birthday = photographer.Birthday;
            Notes = photographer.Notes;
        }
    }
}
