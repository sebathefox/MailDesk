using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImapX;
using ImapX.Collections;
using ImapX.Enums;
using MailDesk.Core;

namespace Debugger
{
    class Program
    {
        static void Main(string[] args)
        {
            Imap imap = new Imap("sebathefox.dk", 993, true);

            imap.Connect();

            imap.Login("test@sebathefox.dk", "Aa123456&");
            imap.OnMessageReceived += OnReceived;
            
            imap.FetchMails();                
            while (true)
            {
            }

            Console.ReadLine();
        }

        public static void OnReceived(object sender, IdleEventArgs args)
        {
            foreach (Message message in args.Messages)
            {
                Console.WriteLine("Subject: " + message.Subject);
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine(message.Body.Text);
            }
            Console.WriteLine("Finished getting unread mails");
        }
    }
}
