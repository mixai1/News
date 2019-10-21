using Core;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Services.EmailSenderServices
{
    public class EmailSender : IEmailSender
    {
        private const string HOST = "smtp.gmail.com";
        private const string EMAIL = "email@gmail.com";
        private const string PASSWOD = "password";
        private const string FROM = "email @gmail.com";
        private const int PORT = 555;


        public async Task<bool> SendEmailAsync(string subject, string body, IEnumerable<string> to, IEnumerable<string> toCc)
        {
            try
            {


                var client = new SmtpClient(HOST, PORT)
                {
                    Credentials = new NetworkCredential(EMAIL, PASSWOD),
                    EnableSsl = true
                };
                client.Send(FROM, subject, body, string.Join(" ", to));

                return true;
            }
            catch(Exception ex)
            {
             
                return false;
            }
        }
    }
}
