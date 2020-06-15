using System;
using System.Collections.Generic;
using System.Text;
using PicDB.Models;

namespace PicDB.ViewModels
{
    ///
    /// ViewModel for EXIF Data
    ///
    public class EXIFViewModel : BaseViewModel
    {
        ///
        /// Empty Constructor
        ///
        public EXIFViewModel() { }

        ///
        /// Constructor for existing Data
        ///
        public EXIFViewModel(EXIFModel exif)
        {
            if(exif != null)
            {
                DateAndTime = exif.DateAndTime != null ? exif.DateAndTime.ToString() : null;
                Orientation = exif.Orientation != null ? $"{exif.Orientation}°" : null;
                FocalLength = FocalLengthForView(exif.FocalLength);
                FNumber = exif.FNumber != null ? $"f/{exif.FNumber}" : null;
                Exposure = exif.Exposure;
                Iso = exif.Iso.ToString();
            }
        }

        ///
        /// Date and Time of Creation
        ///
        public string DateAndTime { get; set; }

        ///
        /// Orientation
        ///
        public string Orientation { get; set; }

        ///
        /// Focal Length
        ///
        public string FocalLength { get; set; }

        ///
        /// FNumber
        ///
        public string FNumber { get; set; }

        ///
        /// Exposure
        ///
        public string Exposure { get; set; }

        ///
        /// ISO Number
        ///
        public string Iso { get; set; }

        internal string FocalLengthForView(Tuple<float?, float?> focalLength)
        {
            var min = focalLength.Item1;
            var max = focalLength.Item2;
            if (min == null && max == null)
                return null;
            else if (min != null && max != null)
                return $"{min}mm - {max}mm";
            else
                return $"{min ?? max}mm - {max ?? min}mm";
        }
    }
}
