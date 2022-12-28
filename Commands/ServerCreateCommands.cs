using Avalonia.Controls;
using ServerCreation.Engine;
using ServerCreation.ViewModels;
using ServerCreation.Views;
using System;
using System.Threading.Tasks;

namespace ServerCreation.Commands
{
    public class ServerCreateCommands
    {
        static AppSettings settings = AppSettings.GetSettings();
        public static async void ChangeDowloadFolder()
        {
            OpenFolderDialog openFolderDialog = new OpenFolderDialog();
            openFolderDialog.Title = "Выберите папку загрузки сервера";

            string? dialog = await openFolderDialog.ShowAsync(MainWindow.MainWindowPtr);

            if(dialog == "" | dialog == null)
                dialog = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            UCServerCreateViewModel.FileLocation.Value = dialog;
        }
        public static void DowloadCommand(string selectedVer, string selectedCore, string fileLoc, string filename)
        {
            if (settings.IsServer == false)
            {
                if(selectedCore == null && selectedVer == null)
                {
                    UCLogsViewModel.TextLogs.Value += "\nВыберите версию и ядро";
                    return;
                }

                if (fileLoc == "" & fileLoc == null & filename == "" & filename == null)
                {
                    UCLogsViewModel.TextLogs.Value += "\nРасположения или имя файла недопустимы!";
                    return;
                }

                FileDowloader dwnder = new();

                string dlink = UrlGenerator.GetPaperDowload(UCServerCreateViewModel.SelectedVersion, UCServerCreateViewModel.SelectedBuild);
                dwnder.Dowload(dlink, UCServerCreateViewModel.FileLocation.Value);
                UCLogsViewModel.TextLogs.Value += dlink;

                UCServerCreateViewModel.DowloadPersents.Value = dwnder.Info.PersentsReady;
                UCLogsViewModel.TextLogs.Value += dwnder.IsDowloading;
                UCLogsViewModel.TextLogs.Value += dwnder.IsDowloadFinished;

                var dtask = Task.Factory.StartNew(() =>
                {



                });

            }
            else
            {
                if(selectedCore == null && selectedVer == null)
                {
                    UCLogsViewModel.TextLogs.Value += "\nВыберите версию и ядро";
                    return;
                }

                if(filename == "" & filename == null)
                {
                    UCLogsViewModel.TextLogs.Value += "\nРасположения или имя файла недопустимы!";
                    return;
                }

                ConnectToServer.SendMessage(selectedVer + "-" + selectedCore, filename + ".jar");
            }
        }
        public static void ConnectCommand()
        {
            ConnectToServer.Connect();
        }
        public static void Disconnect()
        {
            ConnectToServer.Disconnect();
        }
    }
}
