using Avalonia.Controls;
using ServerCreation.Engine;
using ServerCreation.ViewModels;
using ServerCreation.Views;
using System;
using System.Threading.Tasks;

namespace ServerCreation.Commands
{
    public class DeligateCommands 
    {
        //UCServerCreateVM Commands
        static AppSettings settings = AppSettings.GetSettings();

        public static async void ChangeDowloadFolder()
        {
            MainWindow mv = new MainWindow();

            OpenFolderDialog openFolderDialog = new OpenFolderDialog();
            openFolderDialog.Title = "Выберите папку загрузки сервера";

            UCServerCreateViewModel.FileLocation.Value = string.Join("", await openFolderDialog.ShowAsync(mv));
        }
        public static void DowloadCommand(string selectedVer, string selectedCore, string fileLoc, string filename)
        {
            if(settings.IsServer == false)
            {
                if (selectedCore != null && selectedVer != null)
                {
                    if (fileLoc != "" & fileLoc != null & filename != "" & filename != null)
                        VersionsContoller.VersionsManager(selectedVer + "-" + selectedCore, $"{fileLoc}" + "\\" + filename + ".jar");
                    else
                        UCLogsViewModel.TextLogs.Value += "\nРасположения или имя файла недопустимы!";
                }
                else
                    UCLogsViewModel.TextLogs.Value += "\nВыберите версию и ядро";
            }
            else
            {
                if (selectedCore != null && selectedVer != null)
                {
                    if (filename != "" & filename != null)
                        ConnectToServer.SendMessage(selectedVer + "-" + selectedCore, filename + ".jar");
                    else
                        UCLogsViewModel.TextLogs.Value += "\nРасположения или имя файла недопустимы!";
                }
                else
                    UCLogsViewModel.TextLogs.Value += "\nВыберите версию и ядро";
            }
        }
        public static async void ConnectCommand()
        {
            ConnectToServer.Connect();
        }

        //UCOptionsVM Commands
        public static async void ChangeJavaLocationFolderCommand()
        {
            MainWindow mv = new MainWindow();

            OpenFolderDialog openFolderDialog = new OpenFolderDialog();
            openFolderDialog.Title = "Укажите путь к Java";

            UCOptionsViewModel.JavaFolder.Value = string.Join("", await openFolderDialog.ShowAsync(mv));
        }

        //UCServerStarter 
        public static void SendCommandToServer()
        {
            try
            {
                USServerStarterViewModel.TextIn.Value += $"\n{USServerStarterViewModel.TextOut.Value}";

                ServersRemouter.streamWr.WriteLine(USServerStarterViewModel.TextOut.Value);
                ServersRemouter.streamWr.Flush();
            }
            catch (Exception exp)
            {
                USServerStarterViewModel.TextIn.Value += $"\n{exp.Message}";
            }
        }
        public static void StartServer()
        {
            ServersRemouter sm = new();
            sm.StartServer();

            USServerStarterViewModel.TextIn.Value += Environment.OSVersion.Platform;
        }

    }
}
