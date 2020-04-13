using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using PicDB.Models;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace PicDB.ViewModels
{
    public class PictureViewModel : BaseViewModel
    {
        public PictureViewModel() { }
        public PictureViewModel(PictureModel pic)
        {
            Id = pic.Id;
            //Iptc = new IPTCViewModel(BusinessLayer.GetIPTC(pic.Id));
            //Exif = new EXIFViewModel(BusinessLayer.GetEXIF(pic.Id));
            FilePath = Path.Combine(Directory.GetCurrentDirectory(), "images", pic.FilePath, pic.FileName); //not needed yet, remove maybe
            Image = BusinessLayer.PictureToImage(pic);
        }

        public int Id { get; set; }
        public string FilePath { get; set; }    //Do we even need this information with our PictureViewModel?
        //public IPTCViewModel Iptc { get; set; }
        //public EXIFViewModel Exif { get; set; }
        public Image Image { get; set; }

        private PhotographerViewModel _photographer;
        public PhotographerViewModel Photographer
        {
            get { return _photographer; }
            set
            {
                if(_photographer != value)
                {
                    _photographer = value;
                    OnPropertyChanged("Photographer");
                }
            }
        }
    }
}
