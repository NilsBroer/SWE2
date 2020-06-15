using System;
using System.Collections.Generic;
using System.Text;
using PicDB.Models;

namespace PicDB.ViewModels
{
    ///
    /// ViewModel for the Photographer
    ///
    public class PhotographerViewModel : BaseViewModel
    {
        ///
        /// Empty Constructor
        ///
        public PhotographerViewModel() { }

        ///
        /// Constructor for existing Data
        ///
        public PhotographerViewModel(PhotographerModel photographer)
        {
            if(photographer != null)
            {
                Id = photographer.Id;
                Name = photographer.Name;
                Surname = photographer.Surname;
                Birthday = photographer.Birthday;
                Notes = photographer.Notes;
                FullName = Name + " " + Surname;
            }
        }

        ///
        /// Photographer ID
        ///
        public int Id { get; }

        ///
        /// Photographer Name
        ///
        public String Name { get; set; }

        ///
        /// Photographer Surname
        ///
        public String Surname { get; set; }

        ///
        /// Combined Name 
        ///
        public String FullName { get; set; }

        ///
        /// Birthday
        ///
        public DateTime? Birthday { get; set; }

        ///
        /// Additional Notes
        ///
        public String Notes { get; set; }
    }
}
