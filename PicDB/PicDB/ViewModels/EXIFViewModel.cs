using System;
using System.Collections.Generic;
using System.Text;
using PicDB.Models;

namespace PicDB.ViewModels
{
    public class EXIFViewModel : BaseViewModel
    {
        public EXIFViewModel() { }
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

        public string DateAndTime { get; set; }
        public string Orientation { get; set; }
        public string FocalLength { get; set; }
        public string FNumber { get; set; }
        public string Exposure { get; set; }
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
