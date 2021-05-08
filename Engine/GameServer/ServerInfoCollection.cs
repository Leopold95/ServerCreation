using Newtonsoft.Json;
using ServerCreation.Engine.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ServerCreation.Engine.GameServer
{
    public class ServerInfoCollection
    {
        private static ObservableCollection<ServerCollectionModel> ServerCollection = new();


        public static void SetServerCollection(ObservableCollection<ServerCollectionModel> call)
        {
            ServerCollection = call;
        }

        public static ObservableCollection<ServerCollectionModel> GetServerCollection()
        {
            return ServerCollection;
        }
    }
}
