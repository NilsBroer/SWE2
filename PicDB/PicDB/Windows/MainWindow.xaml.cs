using System;
using System.Configuration;
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

            Log.Information("Application Startup");
        }
    }
}
