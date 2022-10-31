using Downloader;
using ServerCreation.Engine.FilesManager;
using System.ComponentModel;
using System.Net;
using System.Reflection;
using DownloadProgressChangedEventArgs = Downloader.DownloadProgressChangedEventArgs;

namespace ServerCreation.Engine
{
    public class FileDowloader
    {
        public bool IsDowloading { get; private set; }

        public DowloadInfo Info { get; private set; } = new();

        public void Dowload(string url, string fileName)
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

            DownloadService downloader = new DownloadService(downloadOpt);

            downloader.DownloadStarted += OnDowloadStarted;
            downloader.DownloadFileCompleted += OnDownloadFileCompleted;
            downloader.DownloadProgressChanged += OnDowloadProgresChanged;

            downloader.DownloadFileTaskAsync(url, fileName);
        }

        void OnDowloadStarted(object sender, DownloadStartedEventArgs e)
        {
            IsDowloading = true;
        }

        void OnDownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            IsDowloading = false;
            Info.Clear();
        }

        void OnDowloadProgresChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Info.Update(ref e);
        }
    }
}