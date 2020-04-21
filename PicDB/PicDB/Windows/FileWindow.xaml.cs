using System.Collections.Generic;
using System.Windows.Controls;
using PicDB.ViewModels;

namespace PicDB
{
    /// <summary>
    /// Interaction logic for FileWindow.xaml
    /// </summary>
    public partial class FileWindow : UserControl
    {
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
            }
        }

        void changeIPTC(object id)
        {
            var iptc = BusinessLayer.GetIPTC(id);
            if(iptc != null)
            {
                LicenseBox.Text = iptc.License ?? LicenseBox.Text;
                CategoryBox.Text = iptc.Category ?? CategoryBox.Text;
                KeyWordsBox.Text = iptc.KeyWords ?? KeyWordsBox.Text;
                PhotographerBox.Text = iptc.PhotographerName ?? PhotographerBox.Text;
                NotesBox.Text = iptc.Notes ?? "";
                //TODO: + selected items = , for submitt with save-button, e.g.:
                //PhotographerBox.SelectedItem = iptc.PhotographerName;
            }
            else
            {
                LicenseBox.Text = "Select License";
                CategoryBox.Text = "Category";
                KeyWordsBox.Text = "KeyWords";
                PhotographerBox.Text = "Select Photographer";
                NotesBox.Text = "Notes";
                //TODO: Unselect item?
            }
        }

        private void SearchButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SearchViewModel searchViewModel = new SearchViewModel(SearchBox.Text);
            if (!searchViewModel.IsSpecific && !searchViewModel.HasMultiple)
            {
                PictureListViewModel pictureListViewModel = new PictureListViewModel(BusinessLayer.GetPicturesOneParam(searchViewModel.Search));
                ImageHolder.ItemsSource = BusinessLayer.PicturesToImages(BusinessLayer.GetPicturesOneParam(searchViewModel.Search)); //Merge with above aka use ViewModel?
                MainImageHolder.Content = ImageHolder.SelectedItem;
            }

            if(!searchViewModel.IsSpecific && searchViewModel.HasMultiple)
            {
                PictureListViewModel pictureListViewModel = new PictureListViewModel(BusinessLayer.GetPicturesMultipleParams(searchViewModel.MultipleSearch));
                ImageHolder.ItemsSource = BusinessLayer.PicturesToImages(BusinessLayer.GetPicturesMultipleParams(searchViewModel.MultipleSearch));
                MainImageHolder.Content = ImageHolder.SelectedItem;
            }

            if (searchViewModel.IsSpecific)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
