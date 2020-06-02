using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using PicDB.Models;
using System.Windows.Controls;

namespace PicDB.ViewModels
{
    public class PictureListViewModel : BaseViewModel
    {
        private IEnumerable<PictureViewModel> _default;
        private ObservableCollection<PictureViewModel> _list = new ObservableCollection<PictureViewModel>();
        private readonly ObservableCollection<Image> _imageList = new ObservableCollection<Image>();
        private PictureViewModel _selectedPicture;

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

        public int Count { get; set; }
        public int SelectedIndex { get; set; }
        public String PictureString { get; set; }
        public PictureViewModel SelectedPicture { get => _selectedPicture; set { _selectedPicture = value; OnPropertyChanged(nameof(SelectedPicture)); } }
        public IEnumerable<PictureViewModel> List { get => _list; set { _list = (ObservableCollection<PictureViewModel>)value; OnPropertyChanged(nameof(List)); } }
        public IEnumerable<Image> ImageList { get => _imageList; }
        public IEnumerable<PictureViewModel> PreviousPictures { get; set; }
        public IEnumerable<PictureViewModel> NextPictures { get; set; }

        public PictureViewModel SetSearchList(IEnumerable<PictureViewModel> list)
        {
            if (_default == null)
                _default = List;
            List = list;
            return List.FirstOrDefault();
        }

        public PictureViewModel ResetSearch()
        {
            if (_default == null) 
                return null;
            List = _default;
            _default = null;
            return List.FirstOrDefault();
        }
    }
}
