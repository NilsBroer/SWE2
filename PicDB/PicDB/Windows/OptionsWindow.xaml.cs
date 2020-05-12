using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using PicDB.Models;
using WpfAnimatedGif;

namespace PicDB
{
    /// <summary>
    /// Interaction logic for OptionsWindow.xaml
    /// </summary>
    public partial class OptionsWindow : UserControl
    {
        private static int _swap = 1;
        public OptionsWindow()
        {
            InitializeComponent();
            ButtonBase_OnClick(null, null);
        }


        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var image = new BitmapImage();

            if (_swap == 1)
            {
                image.BeginInit();
                image.UriSource = new Uri("../images/internal/wip.gif", UriKind.Relative);
                image.EndInit();
                _swap = 2;
            }
            else
            {
                image.BeginInit();
                image.UriSource = new Uri("../images/internal/nts.gif", UriKind.Relative);
                image.EndInit();
                _swap = 1;
            }
            ImageBehavior.SetAnimatedSource(SwitchingGif, image);
        }
    }
}
