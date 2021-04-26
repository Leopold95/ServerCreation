using Avalonia.Threading;
using ServerCreation.ViewModels;
using SimpleTcp;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WatsonTcp;

namespace ServerCreation.Engine
{
    public class ConnectToServer
    {
        static WatsonTcpClient client;
        static AppSettings settings = AppSettings.GetSettings();

        public static void Connect()
        {
            try
            {
                client = new WatsonTcpClient("127.0.0.1", 8888);
                client.Events.ServerConnected += ServerConnected;
                client.Events.ServerDisconnected += ServerDisconnected;
                client.Events.MessageReceived += MessageReceived;
                client.Connect();



            }
            catch (Exception exp)
            {
                UCLogsViewModel.TextLogs.Value += "\n" + exp.Message;
            }


            static void MessageReceived(object sender, MessageReceivedEventArgs args)
            {
                UCServerCreateViewModel.TextLogs.Value += "\nMessage from " + args.IpPort + ": " + Encoding.UTF8.GetString(args.Data);
            }

            static void ServerConnected(object sender, EventArgs args)
            {
                UCServerCreateViewModel.TextLogs.Value += "\nServer  connected";
            }

            static void ServerDisconnected(object sender, EventArgs args)
            {
                UCServerCreateViewModel.TextLogs.Value += "\nServer disconnected";
            }

        }

        public static void Disconnect()
        {
            client.Disconnect();
        }

        public static void SendMessage(string verCore, string fileName)
        {
            try
            {
                client.Send(verCore + "^" + fileName);

            }
            catch (Exception exp) { UCLogsViewModel.TextLogs.Value += "\n" + exp.Message; }
        }
    }
}
