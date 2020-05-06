using System;
using System.Collections.Generic;
using System.Text;
using PicDB.Models;

namespace PicDB.ViewModels
{
    public class PhotographerViewModel : BaseViewModel
    {
        public PhotographerViewModel() { }
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

        public int Id { get; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String FullName { get; set; }
        public DateTime? Birthday { get; set; }
        public String Notes { get; set; }
    }
}
