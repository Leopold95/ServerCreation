using ServerCreation.ViewModels;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ServerCreation.Engine
{
    public static class FileDowloader
    {
        public static async Task DowloadServer(string url, string fileName)
        {
            try
            {
                UCLogsViewModel.TextLogs.Value += $"\nЗагрузка начата";
                using (WebClient client = new WebClient())
                {
                    client.DownloadFileCompleted += (sender, e) => OnDowloadComplited();

                    client.DownloadProgressChanged += (sender, e) => UCServerCreateViewModel.DowloadPersents.Value = e.ProgressPercentage;

                    client.DownloadFileAsync(new Uri(url), UCServerCreateViewModel.TextLogs.Value + fileName);
                }
            }
            catch (Exception exp) { UCLogsViewModel.TextLogs.Value += $"\n{exp.Message}"; }

            void OnDowloadComplited() 
            {
                UCLogsViewModel.TextLogs.Value += $"\nЗагрузка завершена";
                UCServerCreateViewModel.DowloadPersents.Value = 0;
            }

        }
    }
}