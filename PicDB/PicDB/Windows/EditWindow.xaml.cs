using System;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Media;
using PicDB.ViewModels;

namespace PicDB
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : UserControl
    {
        readonly PhotographerListViewModel _photographerListViewModel;
        readonly SolidColorBrush _red = new BrushConverter().ConvertFromString("IndianRed") as SolidColorBrush;
        readonly SolidColorBrush _green = new BrushConverter().ConvertFromString("LightGreen") as SolidColorBrush;

        public EditWindow()
        {
            InitializeComponent();
            _photographerListViewModel = new PhotographerListViewModel(BusinessLayer.GetAllPhotographers());
            PhotographerListBox.ItemsSource = _photographerListViewModel.PhotographerViewModels;
        }

        //Events
        void ChangePhotographer(object sender, SelectionChangedEventArgs args)
        {
            if (PhotographerListBox.SelectedItem != null)
            {
                PhotographerViewModel photographer = (PhotographerViewModel)PhotographerListBox.SelectedItem;
                FirstnameBox.Text = photographer.Name ?? "First Name";
                SurnameBox.Text = photographer.Surname ?? "Surname";
                BirthdayBox.SelectedDate = photographer.Birthday.GetValueOrDefault(DateTime.Today);
                NotesBox.Text = photographer.Notes ?? "Notes";
            }
        }

        private void FirstnameBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            _photographerListViewModel.ValidFirstName = ((TextBox)sender).Text.Length <= 100;

            ((TextBox)sender).Background = _photographerListViewModel.ValidFirstName ? _green : _red;
        }

        private void SurnameBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            _photographerListViewModel.ValidSurname = ((TextBox)sender).Text.Length <= 50;

            ((TextBox)sender).Background = _photographerListViewModel.ValidSurname ? _green : _red;
        }

        private void BirthdayBox_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            _photographerListViewModel.ValidBirthday = ((DatePicker)sender).SelectedDate <= DateTime.Today;

            ((DatePicker)sender).Background = _photographerListViewModel.ValidBirthday ? _green : _red;
        }

        private void NotesBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            _photographerListViewModel.ModifiedNotes = true;
            ((TextBox)sender).Background = _green;
        }

        private void Update_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void Create_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
