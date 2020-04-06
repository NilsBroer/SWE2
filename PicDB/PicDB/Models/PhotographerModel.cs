using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace PicDB.Models
{
    class PhotographerModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public DateTime? Birthday { get; set; }
        public String Notes { get; set; }
    }
}
