using System;

namespace PicDB.Models
{
    class PictureModel
    {
        public int Id { get; set; }
        public String FileName { get; set; }
        public String FilePath { get; set; }
        public PhotographerModel Photographer { get; set; }
        //Not in DB:
        public ExifModel Exif { get; set; }
        public IptcModel Iptc { get; set; }
    }
}
