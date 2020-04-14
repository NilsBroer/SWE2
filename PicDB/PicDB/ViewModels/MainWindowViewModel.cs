using System;
using System.Collections.Generic;
using System.Text;
using PicDB.Models;

namespace PicDB.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public PictureListViewModel pictureListViewModel = new PictureListViewModel();

        public PictureListViewModel List { get; } = new PictureListViewModel();
        public SearchViewModel Search { get; } = new SearchViewModel();
    }
}
