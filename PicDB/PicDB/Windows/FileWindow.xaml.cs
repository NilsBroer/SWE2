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
            ImageHolder.ItemsSource = pictureListViewModel.ImageList;
            MainImageHolder.Content = ImageHolder.SelectedItem;
        }

        //TODO: Auslagern
        void changeImage(object sender, SelectionChangedEventArgs args)
        {
            Image Clone = new Image() { Source = ((Image)(ImageHolder.SelectedItem)).Source };
            MainImageHolder.Content = Clone;
        }
    }
}
