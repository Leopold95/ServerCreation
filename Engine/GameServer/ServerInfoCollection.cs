using Newtonsoft.Json;
using ServerCreation.Engine.Core;
using ServerCreation.ViewModels;
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
            foreach (var item in ServerCollection)
            {
                Tabs tabs = new Tabs();
                tabs.Header = item.ServerName;

                USServerStarterViewModel.TabItems.Add(tabs);
            }
        }

        public static ObservableCollection<ServerCollectionModel> GetServerCollection()
        {
            return ServerCollection;
        }
    }
}
