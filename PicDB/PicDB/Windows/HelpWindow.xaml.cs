using System;
using System.Windows;
using System.Windows.Controls;
using PicDB.Helper;


namespace PicDB
{
    /// <summary>
    /// Interaction logic for HelpWindow.xaml
    /// </summary>
    public partial class HelpWindow : UserControl
    {
        public HelpWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            String name = Name.Text;
            String from = Mail.Text;
            String subject = Subject.Text;
            String body = Message.Text;

            var client = MailHelper.DefaultSmtpClient;
            var message = MailHelper.CreateMailMessage(from, name, subject, body);

            try
            {
                client.Send(message);
                Response.Text = "Status: Success";
            }
            catch (Exception exception)
            {
                Response.Text = $"Status: Failure [{exception}]";
            }
        }
    }
}