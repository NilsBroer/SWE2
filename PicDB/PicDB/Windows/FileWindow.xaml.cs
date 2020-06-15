using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PicDB.Models;
using PicDB.ViewModels;

namespace PicDB
{
    /// <summary>
    /// Interaction logic for FileWindow.xaml
    /// </summary>
    public partial class FileWindow : UserControl
    {
        ///
        /// Initialization for the FileWindow
        ///
        public FileWindow()
        {
            InitializeComponent();
            Objects.ComboBox labelBoxDataContext = new Objects.ComboBox()
            {
                Name = "Select License",
                Options = new List<string>()
                {
                    "Option 1",
                    "Option 2",
                    "Option 3",
                    "I don't have a license"
                }
            };
            LicenseBox.DataContext = labelBoxDataContext;

            PhotographerBox.Text = "Select Photographer";
            PhotographerBox.ItemsSource = BusinessLayer.GetAllPhotographerNames();
            PictureListViewModel pictureListViewModel = new PictureListViewModel();
            ImageHolder.ItemsSource = pictureListViewModel.ImageList;
            MainImageHolder.Content = ImageHolder.SelectedItem;
        }

        //Events
        void changeImage(object sender, SelectionChangedEventArgs args)
        {
            if (ImageHolder.SelectedItem != null)
            {
                var image = BusinessLayer.CloneImage(ImageHolder.SelectedItem);
                MainImageHolder.Content = image;
                changeIPTC(image.Tag);
                changeEXIF(image.Tag);
            }
        }

        void changeEXIF(object id)
        {
            var exif = new EXIFViewModel(BusinessLayer.GetEXIF(id));

            DateTimeBlock.Text = exif.DateAndTime; // ?? "DD:MM:YYYY hh:mm:ss";
            OrientationBlock.Text = exif.Orientation; // ?? "XX°";
            FocalLengthBlock.Text = exif.FocalLength; // ?? "XXmm - YYmm";
            FNumberBlock.Text = exif.FNumber; // ?? "f/X.X";
            ExposureBlock.Text = exif.Exposure; // ?? "1/XXX or Y\"";
            IsoBlock.Text = exif.Iso; // ?? "XXX";
        }

        void changeIPTC(object id)
        {
            var iptc = new IPTCViewModel(BusinessLayer.GetIPTC(id));

            LicenseBox.Text = iptc.License ?? "Select License";
            CategoryBox.Text = iptc.Category ?? "Category";
            KeyWordsBox.Text = iptc.KeyWords ?? "KeyWords";
            PhotographerBox.Text = iptc.PhotographerName ?? "Select Photographer";
            NotesBox.Text = iptc.Notes ?? "Notes...";
        }

        void saveIPTC(object id)
        {
            var iptc = new IPTCModel() //Skips ViewModelLayer
            {
                PictureId = (int)id,
                License = (string) (LicenseBox.SelectedItem ?? LicenseBox.Text),
                Category = CategoryBox.Text,
                KeyWords = KeyWordsBox.Text,
                PhotographerName = (string) (PhotographerBox.SelectedItem ?? PhotographerBox.Text),
                Notes = NotesBox.Text
            };
            BusinessLayer.SaveIPTC(iptc);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var image = (Image)(MainImageHolder.Content);
            if(image != null) { saveIPTC(image.Tag); }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            SearchViewModel searchViewModel = new SearchViewModel(SearchBox.Text);
            if (!searchViewModel.IsActive)
            {
                PictureListViewModel pictureListViewModel = new PictureListViewModel(BusinessLayer.GetAllPictures());
                ImageHolder.ItemsSource = BusinessLayer.PicturesToImages(BusinessLayer.GetAllPictures()); //TODO: Merge with above aka use ViewModel
                MainImageHolder.Content = ImageHolder.SelectedItem;
            }
            else if (!searchViewModel.IsSpecific && !searchViewModel.HasMultiple)
            {
                PictureListViewModel pictureListViewModel = new PictureListViewModel(BusinessLayer.GetPicturesOneParam(searchViewModel.Search));
                ImageHolder.ItemsSource = BusinessLayer.PicturesToImages(BusinessLayer.GetPicturesOneParam(searchViewModel.Search)); //TODO: Merge with above aka use ViewModel
                MainImageHolder.Content = ImageHolder.SelectedItem;
            }
            else if(!searchViewModel.IsSpecific && searchViewModel.HasMultiple)
            {
                PictureListViewModel pictureListViewModel = new PictureListViewModel(BusinessLayer.GetPicturesMultipleParams(searchViewModel.MultipleSearch));
                ImageHolder.ItemsSource = BusinessLayer.PicturesToImages(BusinessLayer.GetPicturesMultipleParams(searchViewModel.MultipleSearch)); //TODO: Merge with above aka use ViewModel
                MainImageHolder.Content = ImageHolder.SelectedItem;
            }
            else if (searchViewModel.IsSpecific)
            {
                throw new System.NotImplementedException();
            }
        }
        
        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            //if(e.Key == Key.Return) //Uncomment if performance issues surface
                SearchButton_Click(sender, e);
        }

        private void SearchBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            SearchBox.Text = "";
        }

        private void SearchBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if(SearchBox.Text.Length == 0) { SearchBox.Text = "Search..."; }
        }
    }
}