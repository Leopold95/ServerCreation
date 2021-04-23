using Avalonia;
using Avalonia.Threading;
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
            await Task.Run(() => 
            {
                try
                {
                    using (WebClient client = new WebClient())
                    {                       
                        Dispatcher.UIThread.InvokeAsync(new Action(() => { UCLogsViewModel.TextLogs.Value += $"\nЗагрузка начата"; }));

                        client.DownloadFileCompleted += (sender, e) => Dispatcher.UIThread.InvokeAsync(new Action(() => { UCLogsViewModel.TextLogs.Value += $"\nЗагрузка завершена"; }));

                        client.DownloadProgressChanged += (sender, e) => Dispatcher.UIThread.InvokeAsync(new Action(() => { UCServerCreateViewModel.DowloadPersents.Value = e.ProgressPercentage; }));

                        client.DownloadFile(new Uri(url), UCServerCreateViewModel.TextLogs.Value + fileName);
                    }
                }
                catch (Exception exp) { UCLogsViewModel.TextLogs.Value += $"\n{exp.Message}"; }

                void OnDowloadComplited()
                {
                    UCServerCreateViewModel.DowloadPersents.Value = 0;
                
                    
                }
            });
        }
    }
}