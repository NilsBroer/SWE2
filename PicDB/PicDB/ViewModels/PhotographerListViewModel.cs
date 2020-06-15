using System;
using System.Collections.Generic;
using System.Text;
using PicDB.Models;

namespace PicDB.ViewModels
{
    ///
    /// ViewModel for the List of all Photographers
    ///
    public class PhotographerListViewModel
    {
        ///
        /// Empty Constructor
        ///
        public PhotographerListViewModel() { }

        ///
        /// Constructor for existing data
        ///
        public PhotographerListViewModel(List<PhotographerModel> models)
        {
            foreach (PhotographerModel model in models)
            {
                PhotographerViewModels.Add(new PhotographerViewModel(model));
                AmountOfPhotographers++;
            }
        }

        ///
        /// List of all Photographers
        ///
        public List<PhotographerViewModel> PhotographerViewModels { get; set; } = new List<PhotographerViewModel>();

        ///
        /// Counts the Photographers in the List
        ///
        public int AmountOfPhotographers { get; set; }

        ///
        /// Whether the FirstName is constraint Compliant
        ///
        public bool ValidFirstName { get; set; } = false;

        ///
        /// Whether the Surname is Constraint Compliant
        ///
        public bool ValidSurname { get; set; } = false;

        ///
        /// Whether the BDay is before Today
        ///
        public bool ValidBirthday { get; set; } = false;

        ///
        /// Whether the Notes have been Modified
        ///
        public bool ModifiedNotes { get; set; } = false;
    }
}
