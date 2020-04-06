using System.Windows.Controls;
using PicDB.Models;

namespace PicDB
{
    /// <summary>
    /// Interaction logic for OptionsWindow.xaml
    /// </summary>
    public partial class OptionsWindow : UserControl
    {
        public OptionsWindow()
        {
            InitializeComponent();
            //Get a Photographer by ID (Just tested whether the DataAccessLayer worked with this one)
            PhotographerModel photographer = DataAccessLayer.GetPhotographer(1);

            MyLabel1.Content = "Name: " + photographer.Name;
            MyLabel2.Content = "Surname: " + photographer.Surname;
            MyLabel3.Content = "Notes: " + photographer.Notes;
            MyLabel4.Content = "Birthday: " + photographer.Birthday;
        }
    }
}
