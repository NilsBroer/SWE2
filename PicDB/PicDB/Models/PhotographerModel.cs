using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using PicDB.ViewModels;

namespace PicDB.Models
{
    public class PhotographerModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public DateTime? Birthday { get; set; }
        public String Notes { get; set; }

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
