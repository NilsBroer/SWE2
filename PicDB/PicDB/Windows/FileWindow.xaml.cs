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

            LabelBox.DataContext = labelBoxDataContext;


            PhotographerBox.ItemsSource = BusinessLayer.GetAllPhotographerNames();
            PictureListViewModel pictureListViewModel = new PictureListViewModel();
            MainImageHolder.Content = pictureListViewModel.SelectedPicture.Image;//BusinessLayer.PictureToImage(BusinessLayer.GetPicture(/*155 + 0*/));

            
            ImageHolder.ItemsSource = pictureListViewModel.ImageList;
            /*
            List<Image> imageList = BusinessLayer.PicturesToImages(BusinessLayer.GetAllPictures());
            foreach (Image image in imageList)
            {
                ImageHolder.Children.Add(image);    //TODO: Replace WrapPanel (siehe notes)
            }
            */
        }
    }
}
