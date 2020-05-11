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
        PhotographerListViewModel _photographerListViewModel;
        readonly SolidColorBrush _red = new BrushConverter().ConvertFromString("IndianRed") as SolidColorBrush;
        readonly SolidColorBrush _green = new BrushConverter().ConvertFromString("LightGreen") as SolidColorBrush;

        public EditWindow()
        {
            InitializeComponent();
            _photographerListViewModel = new PhotographerListViewModel(BusinessLayer.GetAllPhotographers());

            _photographerListViewModel.ValidBirthday = true;
            _photographerListViewModel.ValidFirstName = FirstnameBox.Text.Length <= 100;
            _photographerListViewModel.ValidSurname = SurnameBox.Text.Length <= 50;

            FirstnameBox.Background = _photographerListViewModel.ValidFirstName ? _green : _red;
            SurnameBox.Background = _photographerListViewModel.ValidSurname ? _green : _red;
            BirthdayBox.Background = _photographerListViewModel.ValidBirthday ? _green : _red;
            NotesBox.Background = _green;

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
                BirthdayBox.SelectedDate = photographer.Birthday;
                NotesBox.Text = photographer.Notes ?? "Notes";
            }
        }

        private void FirstnameBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            _photographerListViewModel.ValidFirstName = ((TextBox)sender).Text.Length <= 100;

            ((TextBox)sender).Background = _photographerListViewModel.ValidFirstName ? _green : _red;
        }

        private void SurnameBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            _photographerListViewModel.ValidSurname = ((TextBox)sender).Text.Length <= 50;

            ((TextBox)sender).Background = _photographerListViewModel.ValidSurname ? _green : _red;
        }

        private void BirthdayBox_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            _photographerListViewModel.ValidBirthday = (((DatePicker)sender).SelectedDate <= DateTime.Today) || ((DatePicker)sender).SelectedDate == null;

            ((DatePicker)sender).Background = _photographerListViewModel.ValidBirthday ? _green : _red;
        }

        private void NotesBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            _photographerListViewModel.ModifiedNotes = true;
            ((TextBox)sender).Background = _green;
        }

        private void Update_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (PhotographerListBox.SelectedItem != null && _photographerListViewModel.ValidBirthday && _photographerListViewModel.ValidFirstName && _photographerListViewModel.ValidSurname)
            {
                PhotographerViewModel vm = (PhotographerViewModel)PhotographerListBox.SelectedItem;
                
                if (BirthdayBox.SelectedDate <= DateTime.Today)
                    vm.Birthday = BirthdayBox.SelectedDate;
                if (SurnameBox.Text != "Surname" && SurnameBox.Text.Replace(" ", "").Length > 0)
                    vm.Surname = SurnameBox.Text;
                if (FirstnameBox.Text != "First Name" && FirstnameBox.Text.Replace(" ", "").Length > 0)
                    vm.Name = FirstnameBox.Text;
                if (_photographerListViewModel.ModifiedNotes)
                    vm.Notes = NotesBox.Text;

                BusinessLayer.UpdatePhotographer(vm);
                _photographerListViewModel = new PhotographerListViewModel(BusinessLayer.GetAllPhotographers());

                _photographerListViewModel.ValidBirthday = true;
                _photographerListViewModel.ValidFirstName = true;
                _photographerListViewModel.ValidSurname = true;

                PhotographerListBox.ItemsSource = _photographerListViewModel.PhotographerViewModels;
                PhotographerListBox.SelectedItem = _photographerListViewModel.PhotographerViewModels[0];
            }
        }

        private void Create_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //This seems botchy, but currently you can bypass the "live" validity check with backspace, as this doesn't register as a keystroke, so we have to check it again for creation
            _photographerListViewModel.ValidFirstName = (SurnameBox.Text != "Surname" && SurnameBox.Text.Replace(" ", "").Length > 0);
            _photographerListViewModel.ValidSurname = (FirstnameBox.Text != "First Name" && FirstnameBox.Text.Replace(" ", "").Length > 0);

            if (_photographerListViewModel.ValidBirthday && _photographerListViewModel.ValidFirstName && _photographerListViewModel.ValidSurname)
            {
                PhotographerViewModel vm = new PhotographerViewModel();

                if (BirthdayBox.SelectedDate <= DateTime.Today)
                    vm.Birthday = BirthdayBox.SelectedDate;

                vm.Surname = SurnameBox.Text;
                vm.Name = FirstnameBox.Text;

                if (_photographerListViewModel.ModifiedNotes)
                    vm.Notes = NotesBox.Text;

                BusinessLayer.CreatePhotographer(vm);
                _photographerListViewModel = new PhotographerListViewModel(BusinessLayer.GetAllPhotographers());
                PhotographerListBox.ItemsSource = _photographerListViewModel.PhotographerViewModels;
            }
        }
    }
}
