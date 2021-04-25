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
            client = new SimpleTcpClient("127.0.0.1:8888");
            client.Events.Connected += Connected;
            client.Events.Disconnected += Disconnected;
            client.Events.DataReceived += DataReceived;

            try
            {
                client.Connect();
            }
            catch(Exception exp)
            {
                UCLogsViewModel.TextLogs.Value += "\n" + exp.Message;
            }
            // let's go!

            // once connected to the server...
        }

        static void Connected(object sender, EventArgs e)
        {
            UCServerCreateViewModel.TextLogs.Value += $"\nПодключено к серверу успешно";
        }

        static void Disconnected(object sender, EventArgs e)
        {
            UCServerCreateViewModel.TextLogs.Value += $"\nОтключеное от сервера";
        }

        static void DataReceived(object sender, DataReceivedEventArgs e)
        {
            UCServerCreateViewModel.TextLogs.Value += $"\nОтвет: {Encoding.UTF8.GetString(e.Data)}";           
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
