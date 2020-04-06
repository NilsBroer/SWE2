using System.Collections.Generic;
using System.Windows.Controls;


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

            MainImageHolder.Content = BusinessLayer.PictureToImage(DataAccessLayer.GetPicture(/*155 + 0*/));

            List<Image> imageList = BusinessLayer.PicturesToImages(DataAccessLayer.GetAllPictures());
            foreach (Image image in imageList)
            {
                ImageHolder.Children.Add(image);    //TODO: Replace WrapPanel (siehe notes)
            }
        }
    }
}
