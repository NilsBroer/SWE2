using System.Configuration;

namespace PicDB.ViewModels
{
    ///
    /// VM for the Main Window
    ///
    public class MainWindowViewModel : BaseViewModel
    {
        ///
        /// Returns the underlying PictureListVM
        ///
        public PictureListViewModel pictureListViewModel = new PictureListViewModel();

        ///
        /// Returns a List of the Underlying PLVMs
        ///
        public PictureListViewModel List { get; } = new PictureListViewModel();

        ///
        /// Returns the underlying SearchViewModel
        ///
        public SearchViewModel Search { get; } = new SearchViewModel();
    }
}
