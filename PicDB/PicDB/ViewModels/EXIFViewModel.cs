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
                DateAndTime = exif.DateAndTime;
                Orientation = exif.Orientation;
                FocalLength = exif.FocalLength;
                FNumber = exif.FNumber;
                Exposure = exif.Exposure;
                Iso = exif.Iso;
            }
        }

        public DateTime? DateAndTime { get; set; }
        public int? Orientation { get; set; }
        public Tuple<float?, float?> FocalLength { get; set; }
        public float? FNumber { get; set; }
        public float? Exposure { get; set; }
        public int? Iso { get; set; }
    }
}
