using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCreation.Engine.GameServer
{
    public class ServerInfoCollection
    {
        private static ObservableCollection<ServerCollectionModel> ServerCollection { get; set; }

        public static void SetServerCollectionInfo(ObservableCollection<ServerCollectionModel> lst)
        {
            ServerCollection = lst;
        }

        public static ObservableCollection<ServerCollectionModel> GetServerCollectionInfo()
        {
            return ServerCollection;
        }
    }

    public class ServerCollectionModel
    {
        public string ServerName { get; set; } = string.Empty;
        public string ServerProcessID { get; set; } = string.Empty;
        public string UsedMemory { get; set; } = string.Empty;
        public string UsedProcessor { get; set; } = string.Empty;
        public string UsedDisk { get; set; } = string.Empty;
    }
}
