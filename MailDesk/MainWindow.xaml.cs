using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ImapX;
using MailDesk.Core;
using MailDesk.Core.View;

namespace MailDesk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Imap imap;

        public MainWindow()
        {
            InitializeComponent();
            //imap.Connect();
        }

        private void GetMailsOnClick(object sender, RoutedEventArgs e)
        {
            ListMail.Items.Clear();
            foreach (Message message in imap.FetchMails())
            {
                ListMail.Items.Add(new Mail(message));
            }
        }

        private void MailSelected(object sender, RoutedEventArgs e)
        {
            Mail mail = (Mail)ListMail.SelectedItems[0];


            SubjectLabel.Content = mail.Subject;
            BodyBlock.Text = mail.Body;
        }

        private void OnLogin(object sender, RoutedEventArgs e)
        {
            imap = new Imap(Server.Text, Int32.Parse(Port.Text), true);
            imap.Connect();
            imap.Login(Email.Text, Password.Password);

            foreach (Message message in imap.FetchMails())
            {
                ListMail.Items.Add(new Mail(message));
            }
        }
    }
}
