using System;
using System.Collections.Generic;
using System.Text;

namespace PicDB.Models
{
    class PictureModel
    {
        public int Id { get; private set; }
        public String FileName { get; set; }
        public String FilePath { get; set; }
        public EXIFModel EXIF { get; set; }
        public IPTCModel IPTC { get; set; }
        public PhotographerModel Photographer { get; set; }
    }
}
