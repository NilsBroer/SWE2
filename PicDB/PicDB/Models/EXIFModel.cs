using System;
using System.Collections.Generic;
using System.Text;

namespace PicDB.Models
{
    class EXIFModel
    {
        public int exifID { get; private set; }
        public DateTime? DatumUndUhrzeit { get; set; } = null;
        public int? Orientierung { get; set; } = null;
        public float? Brennweite { get; set; } = null;
        public float? Blendenzahl { get; set; } = null;
        public float? Belichtungszeit { get; set; } = null;
        public int? ISO { get; set; } = null;
        
        //Datentyp müsste mit NuGet installiert werden. Können wir später machen wenn wir tatsächlich EXIFs schon auslesen.
        //public whatever? Koordinaten { get; set; } = null;
    }
}
