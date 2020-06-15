using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using PicDB.Models;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace PicDB.ViewModels
{
    ///
    /// ViewModel for the Pictures
    ///
    public class PictureViewModel : BaseViewModel
    {
        ///
        /// Empty Constructor
        ///
        public PictureViewModel() { }

        ///
        /// Constructor for existing Data
        ///
        public PictureViewModel(PictureModel pic)
        {
            Id = pic.Id;
            //Iptc = new IPTCViewModel(BusinessLayer.GetIPTC(pic.Id));
            //Exif = new EXIFViewModel(BusinessLayer.GetEXIF(pic.Id));
            FilePath = Path.Combine(Directory.GetCurrentDirectory(), "images", pic.FilePath, pic.FileName); //not needed yet, remove maybe
            Image = BusinessLayer.PictureToImage(pic);
        }

        ///
        /// Picture ID
        ///
        public int Id { get; set; }

        ///
        /// FilePath to the Pic
        ///
        public string FilePath { get; set; }

        ///
        /// Image of the Pic (The thing you can "see")
        ///
        public Image Image { get; set; }

        private PhotographerViewModel _photographer;

        ///
        /// Photographer of the Pic
        ///
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
