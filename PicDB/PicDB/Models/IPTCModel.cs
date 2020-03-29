using System;
using System.Collections.Generic;
using System.Text;

namespace PicDB.Models
{
    class IPTCModel
    {
        public int iptcID { get; private set; }
        public String Kategorie { get; set; } = "";
        public String FreieKategorie1 { get; set; } = "";
        public String FreieKategorie2 { get; set; } = "";
        public String FreieKategorie3 { get; set; } = "";
        public int? Editiert { get; set; } = null;
        public String Stichworte { get; set; } = "";
        public DateTime? Erstellungsdatum { get; set; } = null;
    }
}
