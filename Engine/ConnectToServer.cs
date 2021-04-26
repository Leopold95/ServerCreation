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


namespace ServerCreation.Engine
{
    public class ConnectToServer
    {
        static SimpleTcpClient client;
        static AppSettings settings = AppSettings.GetSettings();

        public static void Connect()
        {
            try
            {
                client = new SimpleTcpClient($"{settings.ServerIp}:{settings.ServerPort}");
                client.Events.Connected += OnConnected;
                client.Events.Disconnected += OnDisconnected;
                client.Events.DataReceived += OnDataReceived;

                client.Connect();
            }
            catch (Exception exp)
            {
                UCLogsViewModel.TextLogs.Value += "\n" + exp.Message;
            }

            static void OnConnected(object sender, EventArgs e)
            {
                UCServerCreateViewModel.TextLogs.Value += $"\nПодключено к серверу успешно";
            }

            static void OnDisconnected(object sender, EventArgs e)
            {
                UCServerCreateViewModel.TextLogs.Value += $"\nОтключеное от сервера";
            }

            static void OnDataReceived(object sender, DataReceivedEventArgs e)
            {
                UCServerCreateViewModel.TextLogs.Value += $"\nОтвет: {Encoding.UTF8.GetString(e.Data)}";
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
