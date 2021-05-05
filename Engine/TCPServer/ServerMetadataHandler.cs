using ServerCreation.Engine.GameServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ServerCreation.ViewModels;
using System.Collections.ObjectModel;

namespace ServerCreation.Engine
{
    public class ServerMetadataHandler
    {
        public static void OnMetadataReceived(string key, string value)
        {
            switch (key)
            {
                case "JsonDowloadInfo":
                    DowloadInfoUpdater.OnNewDowloadInfoInServer(value);
                    break;

                case "ServerList":
                    ServerInfoCollection.SetServerCollectionInfo(JsonConvert.DeserializeObject<ObservableCollection<ServerCollectionModel>>(value));

                    UCLogsViewModel.TextLogs.Value += $"\nServerList - {value}";
                    break;

                case "ServerOutputError":
                    break;

                case "ServerOutputOutput":
                    break;

                case "ServerOutputException":
                    break;

                //case "":
                //    break;

                //case "":
                //    break;

            }
        }
    }
}
