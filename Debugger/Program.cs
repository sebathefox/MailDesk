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
            Imap imap = new Imap("imap.gmail.com", 993, true);

            imap.Connect();

            imap.Login("skrivtilsebastian99@gmail.com", "abebaudel");
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
        }
    }
}
