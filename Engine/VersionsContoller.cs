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
                    var messageBoxStandardWindow = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Info", "Выбранного сочетания версия + ядро не существует");
                    //await messageBoxStandardWindow.ShowDialog(mw);
                    break;
            }
        }
    }
}
