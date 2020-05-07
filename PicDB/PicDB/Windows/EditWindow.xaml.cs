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
        PhotographerListViewModel photographerListViewModel;
        SolidColorBrush red = new BrushConverter().ConvertFromString("IndianRed") as SolidColorBrush;
        SolidColorBrush green = new BrushConverter().ConvertFromString("LightGreen") as SolidColorBrush;

        public EditWindow()
        {
            InitializeComponent();
            photographerListViewModel = new PhotographerListViewModel(BusinessLayer.GetAllPhotographers());
            PhotographerListBox.ItemsSource = photographerListViewModel.PhotographerViewModels;
        }

        //Events
        void changePhotographer(object sender, SelectionChangedEventArgs args)
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
            photographerListViewModel.ValidFirstName = ((TextBox)sender).Text.Length <= 100 ?  true : false;
            
            if (photographerListViewModel.ValidFirstName)
                ((TextBox)sender).Background = green;
            else
                ((TextBox)sender).Background = red;
        }

        private void SurnameBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            photographerListViewModel.ValidSurname = ((TextBox)sender).Text.Length <= 50 ? true : false;

            if (photographerListViewModel.ValidSurname)
                ((TextBox)sender).Background = green;
            else
                ((TextBox)sender).Background = red;
        }

        private void BirthdayBox_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            photographerListViewModel.ValidBirthday = ((DatePicker)sender).SelectedDate <= DateTime.Today ? true : false;

            if (photographerListViewModel.ValidBirthday)
                ((DatePicker)sender).Background = green;
            else
                ((DatePicker)sender).Background = red;
        }

        private void NotesBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            photographerListViewModel.ModifiedNotes = true;
            ((TextBox)sender).Background = green;
        }

        private void Update_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void Create_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
