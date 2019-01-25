using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using ImapX;
using ImapX.Authentication;
using ImapX.Collections;

namespace MailDesk.Core
{
    public class Imap
    {
        private ImapClient client;

        public event EventHandler<IdleEventArgs> OnMessageReceived;

        public Imap(string host, int port, bool ssl)
        {
            client = new ImapClient(host, port, ssl);
            client.OnNewMessagesArrived += (sender, args) => { OnMessageReceived?.Invoke(sender, args);};
        }

        public bool Connect()
        {
            client.SslProtocol = SslProtocols.Tls12;
            Console.WriteLine("Connecting");
            return client.Connect();
        }

        public bool Login(string username, string password)
        {
            
            return client.Login(new PlainCredentials(username, password));
        }

        public FolderCollection GetFolders()
        {
            return client.Folders;
        }

        public Folder GetFolder(string name)
        {
            Console.WriteLine("Is Connected: " + client.IsConnected + "; Is Authenticated: " + client.IsAuthenticated);
            return client.Folders[name];
        }

        public IEnumerable<Folder> WalkFoldersRecursive(FolderCollection folders)
        {
            foreach (Folder folder in folders)
            {
                if (folder.HasChildren)
                {

                    foreach (Folder item in WalkFoldersRecursive(folder.SubFolders))
                    {
                        yield return item;
                    }

                }
                yield return folder;
            }
        }

        public Message[] FetchMails()
        {
            /*foreach (Message message in GetFolder("INBOX").Search("ALL"))
            {
                Console.WriteLine(message.Body.Text);
            }
            Console.WriteLine("kek");*/

            return GetFolder("INBOX").Search("ALL");
        }
    }
}
