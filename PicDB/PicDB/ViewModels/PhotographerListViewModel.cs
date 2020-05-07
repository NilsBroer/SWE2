using System;
using System.Collections.Generic;
using System.Text;
using PicDB.Models;

namespace PicDB.ViewModels
{
    public class PhotographerListViewModel
    {
        public PhotographerListViewModel() { }
        public PhotographerListViewModel(List<PhotographerModel> models)
        {
            foreach (PhotographerModel model in models)
            {
                PhotographerViewModels.Add(new PhotographerViewModel(model));
                AmountOfPhotographers++;
            }
        }

        public List<PhotographerViewModel> PhotographerViewModels { get; set; } = new List<PhotographerViewModel>();
        public int AmountOfPhotographers { get; set; }
        public bool ValidFirstName { get; set; } = false;
        public bool ValidSurname { get; set; } = false;
        public bool ValidBirthday { get; set; } = false;
        public bool ModifiedNotes { get; set; } = false;
    }
}
