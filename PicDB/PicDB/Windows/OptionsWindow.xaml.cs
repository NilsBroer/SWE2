using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
            PhotographerModel photographer = PhotographerDAL.GetPhotographer(2);

            MyLabel1.Content = "Vorname: " + photographer.Vorname;
            MyLabel2.Content = "Nachname: " + photographer.Nachname;
            MyLabel3.Content = "Notizen: " + photographer.Notizen;
            MyLabel4.Content = "Geburtstag: " + photographer.Geburtstag;
        }
    }
}
