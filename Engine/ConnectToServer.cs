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

        public static Thread t = new Thread(new ThreadStart(Connect)) { IsBackground = true, Name = "Is Server Connected", Priority = ThreadPriority.Normal };
        

        static void Connect()
        {
            try
            {
                client = new SimpleTcpClient("127.0.0.1:8888");
                client.Events.Connected += OnConnected;
                client.Events.Disconnected += OnDisconnected;
                client.Events.DataReceived += OnDataReceived;

                client.Connect();
            }
            catch (Exception exp)
            {
                UCLogsViewModel.TextLogs.Value += "\n" + exp.Message;
            }

            static async void OnConnected(object sender, EventArgs e)
            {
                await Dispatcher.UIThread.InvokeAsync(new Action(() => { UCServerCreateViewModel.TextLogs.Value += $"\nПодключено к серверу успешно"; }));
            }

            static async void OnDisconnected(object sender, EventArgs e)
            {
                await Dispatcher.UIThread.InvokeAsync(new Action(() => { UCServerCreateViewModel.TextLogs.Value += $"\nОтключеное от сервера"; }));
            }

            static async void OnDataReceived(object sender, DataReceivedEventArgs e)
            {
                await Dispatcher.UIThread.InvokeAsync(new Action(() => { UCServerCreateViewModel.TextLogs.Value += $"\nОтвет: {Encoding.UTF8.GetString(e.Data)}"; }));
            }
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
