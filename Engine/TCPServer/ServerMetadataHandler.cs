using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCreation.Engine
{
    public class ServerMetadataHandler
    {
        public static void OnMetadataReceived(object key, object value)
        {
            switch (key)
            {
                case "JsonDowloadInfo":
                    DowloadInfoUpdater.OnNewDowloadInfoInServer(value.ToString());
                    break;

                case "ServerList":
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
