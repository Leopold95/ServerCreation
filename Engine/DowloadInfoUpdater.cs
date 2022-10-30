using Downloader;
using Newtonsoft.Json;
using ServerCreation.ViewModels;
using System;

namespace ServerCreation.Engine
{
    public class DowloadInfo
    {
        public int PersentsReady { get; private set; }
        public string Speed { get; private set; } = string.Empty;
        public string SizeReady { get; private set; } = string.Empty;
        public string TotalSize { get; private set; } = string.Empty;

        public void Update(ref DownloadProgressChangedEventArgs e)
        {
            PersentsReady = Convert.ToInt32(e.ProgressPercentage);
            Speed = CalcMemoryMensurableUnit(e.BytesPerSecondSpeed);
            SizeReady = CalcMemoryMensurableUnit(e.ReceivedBytesSize);
            TotalSize = CalcMemoryMensurableUnit(e.TotalBytesToReceive);
        }

        public void Clear()
        {
            PersentsReady = 0;
            Speed = string.Empty;
            SizeReady = string.Empty;
            TotalSize = string.Empty;
        }

        private string CalcMemoryMensurableUnit(double bytes)
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
