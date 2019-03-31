using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MailDesk.Core;

namespace Debugger
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket imapClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            imapClient.Connect("sebathefox.dk", 143);



            byte[] cmd = Encoding.ASCII.GetBytes("LOGIN sebastian@sebathefox.dk [PASSWORD]");

            imapClient.Send(cmd);

            byte[] buff = new byte[1024];

            int bytesReceived = imapClient.Receive(buff);

            Console.WriteLine(Encoding.ASCII.GetString(buff));

            Console.ReadLine();
        }
    }
}
