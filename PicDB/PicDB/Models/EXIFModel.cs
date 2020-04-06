using System;
using System.Collections.Generic;
using System.Text;

namespace PicDB.Models
{
    class ExifModel
    {
        public int Id { get; set; }
        public DateTime? DateAndTime { get; set; }
        public int? Orientation { get; set; }
        public Tuple<float?,float?> FocalLength { get; set; }
        public float? FNumber { get; set; }
        public float? Exposure { get; set; }
        public int? Iso { get; set; }
    }
}
