using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ImapX;
using MailAddress = ImapX.MailAddress;

namespace MailDesk.Core.View
{
    public class Mail
    {
        public Mail(MailAddress sender, MailAddress receipent, string subject, string body)
        {
            Sender = sender;
            Receipent = receipent;
            Subject = subject;
            Body = body;
        }

        public Mail(Message message)
        {
            try
            {

                Sender = message.From;
                Receipent = message.To.First();
                Subject = message.Subject;
                Body = message.Body.Text;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public MailAddress Sender { get; set; }

        public MailAddress Receipent { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }


    }
}
