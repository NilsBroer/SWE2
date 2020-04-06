using System;
using System.Collections.Generic;
using System.Text;

namespace PicDB.Models
{
    class IptcModel
    {
        public int Id { get; set; }
        public string License { get; set; }
        public string PhotographerName { get; set; }
        public String Category { get; set; }
        public int? IsEdited { get; set; }
        public String KeyWords { get; set; }
        public String Notes { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
