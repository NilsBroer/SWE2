using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace PicDB.Helper
{
    ///
    /// Handles the Mailing Function of the Program
    ///
    public static class MailHelper
    {
        ///
        /// Accessor for the SMTP Client
        ///
        public static SmtpClient DefaultSmtpClient = GetSmtpClient();

        ///
        /// Returns the SmtpClient for the Mail 
        ///
        public static SmtpClient GetSmtpClient()
        {
            return new SmtpClient()
            {
                UseDefaultCredentials = false,
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential(
                    ConfigurationManager.AppSettings["DefaultMail"],
                    ConfigurationManager.AppSettings["DefaultMailPassword"])
            };
        }

        private static readonly MailAddress DefaultMailAddress = new MailAddress("SendAndReceiveViaSMTP@gmail.com");

        ///
        /// Creates the Mail to be sent.
        ///
        public static MailMessage CreateMailMessage(string from, string name, string subject, string body)
        {
            var newline = "  \r\n";
            return new MailMessage(DefaultMailAddress, DefaultMailAddress)
            {
                Subject = $"PicDB HelpRequest: {subject}",
                Body = $"FROM: {name} [{from}]" + newline +
                       $"MESSAGE: {newline} {body} {newline}",
                ReplyToList = { new MailAddress(from) }
            };
        }
    }
}