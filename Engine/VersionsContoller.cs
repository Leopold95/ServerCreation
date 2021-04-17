using ServerCreation.ViewModels;
using ServerCreation.Views;

namespace ServerCreation.Engine
{
    public static class VersionsContoller
    {
        public static async void VersionsManager(string verion, string filename)
        {
            switch (verion)
            {
                case "1.16.5-Paper":
                    await FileDowloader.DowloadServer("https://papermc.io/api/v2/projects/paper/versions/1.16.5/builds/592/downloads/paper-1.16.5-592.jar", filename);
                    break;                
                //case "":
                //    break;
                //case "":
                //    break;
                //case "":
                //    break;
                default:
                    UCLogsViewModel.TextLogs.Value += "\nВыбранного сочетания версия + ядро не существует";
                    break;
            }
        }
    }
}
