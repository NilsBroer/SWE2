using System;
using PicDB.ViewModels;

namespace PicDB.Models
{
    ///
    /// Model for the EXIF-Data
    ///
    public class EXIFModel
    {
        ///
        /// PictureID
        ///
        public int PictureId { get; set; }

        ///
        /// Date and Time 
        ///
        public DateTime? DateAndTime { get; set; }

        ///
        /// Orientation in Degrees
        ///
        public int? Orientation { get; set; }

        ///
        /// Focal Length with both values as a Tuple
        ///
        public Tuple<float?,float?> FocalLength { get; set; }

        ///
        /// FNumber
        ///
        public float? FNumber { get; set; }

        ///
        /// Exposure
        ///
        public string Exposure { get; set; }

        ///
        /// ISO Number
        ///
        public int? Iso { get; set; }
    }
}
