using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using PicDB.Models;
using System.Windows.Controls;

namespace PicDB.ViewModels
{
    ///
    /// ViewModel for the List of all Pictures
    ///
    public class PictureListViewModel : BaseViewModel
    {
        private IEnumerable<PictureViewModel> _default;
        private ObservableCollection<PictureViewModel> _list = new ObservableCollection<PictureViewModel>();
        private readonly ObservableCollection<Image> _imageList = new ObservableCollection<Image>();
        private PictureViewModel _selectedPicture;

        ///
        /// Empty Constructor
        ///
        public PictureListViewModel()
        {
            BusinessLayer.GetAllPictures().ForEach(i =>
            {
                _list.Add(new PictureViewModel(i));
            });

            SelectedPicture = _list.FirstOrDefault();

            BusinessLayer.GetAllPictures().ForEach(i =>
            {
                _imageList.Add(BusinessLayer.PictureToImage(i)); //Kann verworfen werden, falls bessere LadeSolution gefunden wird
            });
        }

        ///
        /// Constructor for existing Data
        ///
        public PictureListViewModel(List<PictureModel> models)
        {
            models.ForEach(i =>
            {
                _list.Add(new PictureViewModel(i));
            });

            SelectedPicture = _list.FirstOrDefault();

            models.ForEach(i =>
            {
                _imageList.Add(BusinessLayer.PictureToImage(i)); //Kann verworfen werden, falls bessere LadeSolution gefunden wird
            });
        }


        ///
        /// Returns the Currently Selected Picture, implementing OPC
        ///
        public PictureViewModel SelectedPicture { get => _selectedPicture; set { _selectedPicture = value; OnPropertyChanged(nameof(SelectedPicture)); } }

        ///
        /// List of Pictures implementing OPC
        ///
        public IEnumerable<PictureViewModel> List { get => _list; set { _list = (ObservableCollection<PictureViewModel>)value; OnPropertyChanged(nameof(List)); } }

        ///
        /// List of Images (the Image portion of Pictures)
        ///
        public IEnumerable<Image> ImageList { get => _imageList; }
    }
}
