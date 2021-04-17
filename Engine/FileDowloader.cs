using ServerCreation.ViewModels;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ServerCreation.Engine
{
    public static class FileDowloader
    {
        public static string message;

        public static async Task DowloadServer(string url, string fileName)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFileCompleted += (sender, e) => OnDowloadComplited();
                    client.DownloadProgressChanged += (sender, e) => UCServerCreateViewModel.DowloadPersents.Value = e.ProgressPercentage;

                    client.DownloadFileAsync(new Uri(url), UCServerCreateViewModel.TextLogs.Value +  fileName);
                }

                message = "Загрузка начата";
            }
            catch (Exception exp)
            {
                var messageBoxStandardWindow = MessageBox.Avalonia.MessageBoxManager
  .GetMessageBoxStandardWindow("title", exp.Message);
                messageBoxStandardWindow.Show();
            }

            async void OnDowloadComplited() 
            {
                UCServerCreateViewModel.DowloadPersents.Value = 0;

                var messageBoxStandardWindow = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Info", "DowloadComplited");
                messageBoxStandardWindow.Show();
            }
        }
    }
}