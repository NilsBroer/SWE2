using System;
using PicDB.ViewModels;

namespace PicDB.Models
{
    public class EXIFModel
    {
        public int Id { get; set; }
        public DateTime? DateAndTime { get; set; }
        public int? Orientation { get; set; }
        public Tuple<float?,float?> FocalLength { get; set; }
        public float? FNumber { get; set; }
        public float? Exposure { get; set; }
        public int? Iso { get; set; }

        public void Update(EXIFViewModel exif)
        {
            DateAndTime = exif.DateAndTime;
            Orientation = exif.Orientation;
            FocalLength = exif.FocalLength;
            FNumber = exif.FNumber;
            Exposure = exif.Exposure;
            Iso = exif.Iso;
        }
    }
}
