using Avalonia.Threading;
using Newtonsoft.Json;
using ServerCreation.ViewModels;
using SimpleTcp;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
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
                client = new WatsonTcpClient(settings.ServerIp, settings.ServerPort);
                client.Events.ServerConnected += ServerConnected;
                client.Events.ServerDisconnected += ServerDisconnected;
                client.Events.MessageReceived += MessageReceived;
                client.Connect();
            }
            catch (Exception exp)
            {
                UCLogsViewModel.TextLogs.Value += "\n" + exp.Message;
            }



            static void ServerConnected(object sender, EventArgs args)
            {
                UCServerCreateViewModel.TextLogs.Value += "\nServer  connected";
            }
            static void ServerDisconnected(object sender, EventArgs args)
            {
                UCServerCreateViewModel.TextLogs.Value += "\nServer disconnected";
            }        
            static void MessageReceived(object sender, MessageReceivedEventArgs args)
            {
                if (Encoding.UTF8.GetString(args.Data).Contains("Json"))
                {
                    string[] jsonStrs = Encoding.UTF8.GetString(args.Data).Split('^');
                    DowloadInfoUpdater.OnNewDowloadInfoInServer(jsonStrs[1]);
                }
                else if (Encoding.UTF8.GetString(args.Data).Equals("Загрузка на сервере завершена"))                
                    DowloadInfoUpdater.OnDowloadComplitedOnServer();              
                else
                {
                    UCServerCreateViewModel.TextLogs.Value += $"\n{Encoding.UTF8.GetString(args.Data)}";
                }
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
