using System.Configuration;
using System.IO;
using System.Windows;
using PicDB.ViewModels;

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
            var mainWindowViewModel = new MainWindowViewModel();
            DataContext = mainWindowViewModel;
            Title = mainWindowViewModel.Title; //This is not really useful, just to show how one would do it 
        }
    }
}
