using System.Configuration;

namespace PicDB.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public PictureListViewModel pictureListViewModel = new PictureListViewModel();

        public PictureListViewModel List { get; } = new PictureListViewModel();
        public SearchViewModel Search { get; } = new SearchViewModel();

        public string Title = ConfigurationManager.AppSettings["Title"];
    }
}
