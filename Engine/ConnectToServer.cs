﻿using ServerCreation.ViewModels;
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
                if(args.Metadata != null)
                {
                    foreach (KeyValuePair<object, object> keyValue in args.Metadata)
                    {
                        UCServerCreateViewModel.TextLogs.Value += $"\n{keyValue.Key + " - " + keyValue.Value}";                       
                    }
                    args.Metadata.Clear();
                }
               

                if (Encoding.UTF8.GetString(args.Data).Contains("Json"))
                {
                    string[] jsonStrs = Encoding.UTF8.GetString(args.Data).Split('^');
                    DowloadInfoUpdater.OnNewDowloadInfoInServer(jsonStrs[1]);
                }
                else if (Encoding.UTF8.GetString(args.Data).Equals("Загрузка на сервере завершена"))
                {
                    DowloadInfoUpdater.OnDowloadComplitedOnServer();
                    UCServerCreateViewModel.TextLogs.Value += $"\n{Encoding.UTF8.GetString(args.Data)}";
                }                     
                else
                    UCServerCreateViewModel.TextLogs.Value += $"\n{Encoding.UTF8.GetString(args.Data)}";                
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
