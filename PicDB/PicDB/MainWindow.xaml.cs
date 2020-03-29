using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            String Path;

            if (System.IO.Directory.GetCurrentDirectory().StartsWith(@"C:\Users\Chris"))    
                Path = @"C:\Users\Chris\source\repos\SWE2\PicDB\PicDB";
            else
                Path = @"C:\Users\Nils\Google Drive\UNI\Semester 04\SWE2\PicDB\PicDB";

            List<string> fileNames = new List<string>(System.IO.Directory.EnumerateFiles(Path + "/images/pokemon/","*.png")); //TODO: Adapt search pattern to jp(e)g

            foreach (string fileName in fileNames)
            {
                Image image = new Image
                {
                    Source = new BitmapImage(new Uri(fileName)),
                    Height = 50
                };
                Border border = new Border();
                ImageHolder.Children.Add(image);
            }

            Models.ComboBox CBO1_DC = new Models.ComboBox()
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

            CB01.DataContext = CBO1_DC;
        }
    }
}
