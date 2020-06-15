using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows;

namespace PicDB.ViewModels
{
    ///
    /// Base View Model implementing the INotifyPropertyChanged
    ///
    public abstract class BaseViewModel : DependencyObject, INotifyPropertyChanged
    {
        ///
        /// Event Handler for INPC
        ///
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(String property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}