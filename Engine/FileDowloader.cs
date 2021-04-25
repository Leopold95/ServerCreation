using Avalonia.Threading;
using Downloader;
using ServerCreation.ViewModels;
using System;
using System.ComponentModel;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ServerCreation.Engine
{
    public class FileDowloader
    {
        public static Downloader.DownloadProgressChangedEventArgs dpcea;
        public static void Dowload(string url, string fileName)
        { 
            
            Thread t = new Thread(new ThreadStart(() =>
            {
                DowloadServer(url, fileName);
            }));
            t.Start();
        }
        

        
        
        
        public static async void DowloadServer(string url, string fileName)
        {
            var downloadOpt = new DownloadConfiguration()
            {
                BufferBlockSize = 10240, // usually, hosts support max to 8000 bytes, default values is 8000
                ChunkCount = 8, // file parts to download, default value is 1
                MaximumBytesPerSecond = int.MaxValue, // download speed limited to 1MB/s, default values is zero or unlimited
                MaxTryAgainOnFailover = int.MaxValue, // the maximum number of times to fail
                OnTheFlyDownload = false, // caching in-memory or not? default values is true
                ParallelDownload = true, // download parts of file as parallel or not. Default value is false
                TempDirectory = "C:\\temp", // Set the temp path for buffering chunk files, the default path is Path.GetTempPath()
                Timeout = 1000, // timeout (millisecond) per stream block reader, default values is 1000
                RequestConfiguration = // config and customize request headers
                {
                    Accept = "*/*",
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                    CookieContainer =  new CookieContainer(), // Add your cookies
                    Headers = new WebHeaderCollection(), // Add your custom headers
                    KeepAlive = false,
                    ProtocolVersion = HttpVersion.Version11, // Default value is HTTP 1.1
                    UseDefaultCredentials = false,
                    UserAgent = $"DownloaderSample/{Assembly.GetExecutingAssembly().GetName().Version.ToString(3)}"
                }
            };

            var downloader = new DownloadService(downloadOpt);

            downloader.DownloadStarted += OnDowloadStarted;
            downloader.DownloadFileCompleted += OnDownloadFileCompleted;
            downloader.DownloadProgressChanged += OnDowloadProgresChanged;

            await downloader.DownloadFileTaskAsync(url, fileName);
            

            void OnDowloadStarted(object sender, DownloadStartedEventArgs e)
            {
                UCLogsViewModel.TextLogs.Value += "\nDowload started";
            }

            void OnDownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
            {
                UCLogsViewModel.TextLogs.Value += "\nDowload comlited";
                UCServerCreateViewModel.DowloadPersents.Value = 0;
                UCServerCreateViewModel.ProgressPersentage.Value = "";
            }

            void OnDowloadProgresChanged(object sender, Downloader.DownloadProgressChangedEventArgs e)
            {
                UCServerCreateViewModel.DowloadPersents.Value = Convert.ToInt32(e.ProgressPercentage);
                UCServerCreateViewModel.ProgressPersentage.Value = Convert.ToUInt32(e.ProgressPercentage) + "%";
                dpcea = e;
                //ChageInfo(e);
            }
            
            static string CalcMemoryMensurableUnit(double bytes)
            {
                double kb = bytes / 1024; // · 1024 Bytes = 1 Kilobyte 
                double mb = kb / 1024; // · 1024 Kilobytes = 1 Megabyte 
                double gb = mb / 1024; // · 1024 Megabytes = 1 Gigabyte 
                double tb = gb / 1024; // · 1024 Gigabytes = 1 Terabyte 

                string result =
                    tb > 1 ? $"{tb:0.##}TB" :
                    gb > 1 ? $"{gb:0.##}GB" :
                    mb > 1 ? $"{mb:0.##}MB" :
                    kb > 1 ? $"{kb:0.##}KB" :
                    $"{bytes:0.##}B";

                result = result.Replace("/", ".");
                return result;
            }

        }
        

        
    }
}