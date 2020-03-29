using System;
using System.Collections.Generic;
using System.Text;

namespace PicDB.Models
{
    class PhotographerModel
    {
        public int Id { get; private set; }
        public String Vorname { get; set; }
        public String Nachname { get; set; }
        public DateTime? Geburtstag { get; set; }
        public String Notizen { get; set; }
        public List<PictureModel> Pictures { get; }
    }
}
