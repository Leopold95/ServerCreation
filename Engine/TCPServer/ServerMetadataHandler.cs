using ServerCreation.Engine.GameServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ServerCreation.ViewModels;
using System.Collections.ObjectModel;
using ServerCreation.Engine.Core;

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
                    ServerInfoCollection.SetServerCollection(JsonConvert.DeserializeObject<ObservableCollection<ServerCollectionModel>>(value));

                    UCLogsViewModel.TextLogs.Value += $"\nServerList - {value}";
                    break;

                case "ServerOutputError":
                    GameServerReceivedOutoutHandler.OnError(value);
                    UCLogsViewModel.TextLogs.Value += $"\nServerOutputError - {value}";
                    break;

                case "ServerOutputOutput":
                    GameServerReceivedOutoutHandler.OnNewOutput(value);
                    UCLogsViewModel.TextLogs.Value += $"\nServerOutputOutput - {value}";
                    break;

                case "ServerOutputException":
                    GameServerReceivedOutoutHandler.OnException(value);
                    UCLogsViewModel.TextLogs.Value += $"\nServerOutputException - {value}";
                    break;

                default:
                    UCLogsViewModel.TextLogs.Value += $"\nMetadate is not registred";
                    break;
            }
        }
    }
}
