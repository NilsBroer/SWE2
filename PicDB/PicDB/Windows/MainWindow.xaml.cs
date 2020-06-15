using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Windows;
using PicDB.ViewModels;
using Serilog;

namespace PicDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ///
        /// Initialization for the Main Window
        ///
        public MainWindow()
        {
            InitializeComponent();
            var mainWindowViewModel = new MainWindowViewModel();
            DataContext = mainWindowViewModel;

            var logPath = ConfigurationManager.AppSettings["LogPath"];

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(logPath, rollingInterval: RollingInterval.Day)
                .CreateLogger();

            //@Logging:
            Log.Information("Application Startup (log)"); //Will show up in the log-file, not in the console
            Debug.WriteLine("Application Startup (console)"); //Will show up in the console, not in the log file
        }
    }
}

//TODO: Look through ***Window.cs files, possibly move event functions somewhere else and apply Error Handling with EH.Try