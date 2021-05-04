using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCreation.Engine.GameServer
{
    public class ServerInfoCollection
    {
        public static List<ServerCollectionModel> ServerCollection = new();
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
