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
            Iptc = new IPTCViewModel(pic.Iptc);
            Exif = new EXIFViewModel(pic.Exif);
            FileName = pic.FileName;
            FilePath = pic.FilePath;
            FullPath = Path.Combine(Directory.GetCurrentDirectory(), "images", FilePath, FileName); //not needed yet, remove maybe
            Image = BusinessLayer.PictureToImage(pic);
        }

        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FullPath { get; set; } //not needed yet, remove maybe
        public IPTCViewModel Iptc { get; set; }
        public EXIFViewModel Exif { get; set; }
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
