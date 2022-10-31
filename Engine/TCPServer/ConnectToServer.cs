using ServerCreation.Engine.FilesManager;
using ServerCreation.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
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
            catch (Exception exp) { UCLogsViewModel.TextLogs.Value += "\n" + exp.Message; }
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


        private static void ServerConnected(object sender, EventArgs args)
        {
            UCServerCreateViewModel.TextLogs.Value += "\nServer  connected";
        }
        private static void ServerDisconnected(object sender, EventArgs args)
        {
            UCServerCreateViewModel.TextLogs.Value += "\nServer disconnected";
        }
        private static void MessageReceived(object sender, MessageReceivedEventArgs args)
        {
            if (args.Metadata != null)
            {
                foreach (KeyValuePair<object, object> keyValue in args.Metadata)
                {
                    ServerMetadataHandler.OnMetadataReceived(keyValue.Key.ToString(), keyValue.Value.ToString());
                }
                args.Metadata.Clear();
            }

            if (Encoding.UTF8.GetString(args.Data) != "" & Encoding.UTF8.GetString(args.Data) != string.Empty)
            {
                if (Encoding.UTF8.GetString(args.Data).Contains("Загрузка на сервере завершена"))
                {
                    //DowloadInfo.OnDowloadComplitedOnServer();
                    //TODO
                    UCServerCreateViewModel.TextLogs.Value += $"\n{Encoding.UTF8.GetString(args.Data)}";
                }
                else
                    UCServerCreateViewModel.TextLogs.Value += $"\n{Encoding.UTF8.GetString(args.Data)}";
            }
        }
    }
}
