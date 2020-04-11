using System;
using System.Collections.Generic;
using System.Text;
using PicDB.Models;

namespace PicDB.ViewModels
{
    class SearchViewModel : BaseViewModel
    {
        //Still needs Logic
        public String Search { get; set; }
        public PhotographerModel Photographer { get; set; }
        public EXIFModel EXIF { get; set; }
        public IPTCModel IPTC { get; set; }
    }
}
