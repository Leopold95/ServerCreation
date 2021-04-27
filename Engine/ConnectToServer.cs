using Avalonia.Threading;
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
                string dowloadpercents;
                string speed;
                string toRecive;
                string totalToRecive;

                string str = Encoding.UTF8.GetString(args.Data);

                if (str.Contains("DowloadPercents"))
                {
                    string[] strs = Encoding.UTF8.GetString(args.Data).Split('^');
                    string str1 = strs[0];
                    string str2 = strs[1];

                    string[] strs1 = str1.Split('=');
                    string[] strs2 = str2.Split('+');

                    string[] dowloadPersentstrs = strs1[0].Split('$');
                    string[] serverrDowlaodSpeedStrs = strs1[1].Split('&');

                    string[] dowloadedStrs = strs2[0].Split('*');
                    string[] totaltorecieve = strs2[1].Split('#');

                    dowloadpercents = dowloadPersentstrs[1];
                    speed = serverrDowlaodSpeedStrs[1];

                    totalToRecive = totaltorecieve[1];
                    toRecive = dowloadedStrs[1];

                    UCServerCreateViewModel.DowloadPersents.Value = Convert.ToInt32(dowloadpercents);
                    UCServerCreateViewModel.ProgressPersentage.Value = dowloadpercents;
                    UCServerCreateViewModel.UpdSpeedInfo.Value = $"Скорость: {speed}/s";
                    UCServerCreateViewModel.UpdBytesRecivedInfo.Value = $"Скачано: {toRecive}";
                    UCServerCreateViewModel.UpdTotalBytesRecivedInfo.Value = $"Осталось: {totalToRecive}";

                    //UCServerCreateViewModel.TextLogs.Value += $"\nPercents {dowloadpercents} - Speed {speed} - Dowloaded {totalToRecive}/{totalToRecive}";
                }
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
