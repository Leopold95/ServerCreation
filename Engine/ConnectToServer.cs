using ServerCreation.ViewModels;
using SimpleTcp;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ServerCreation.Engine
{
    public class ConnectToServer
    {
        static SimpleTcpClient client;

        public static void Connect()
        {
            client = new SimpleTcpClient("127.0.0.2:8888");
            client.Events.Connected += Connected;
            client.Events.Disconnected += Disconnected;
            client.Events.DataReceived += DataReceived;

            // let's go!
            client.Connect();

            // once connected to the server...
            client.Send("Hello, world!");
        }

        static void Connected(object sender, EventArgs e)
        {
            Console.WriteLine("*** Server connected");
        }

        static void Disconnected(object sender, EventArgs e)
        {
            Console.WriteLine("*** Server disconnected");
        }

        static void DataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine("[" + e.IpPort + "] " + Encoding.UTF8.GetString(e.Data));
        }

    }
}
