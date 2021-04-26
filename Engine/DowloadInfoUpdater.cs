using Downloader;
using ServerCreation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCreation.Engine
{
    public class DowloadInfoUpdater
    {
        public static void OnNewUpdateInfo(DownloadProgressChangedEventArgs e)
        {
            UCServerCreateViewModel.UpdSpeedInfo.Value = $"Скорость: {CalcMemoryMensurableUnit(e.BytesPerSecondSpeed)}/s";
            UCServerCreateViewModel.UpdBytesRecivedInfo.Value = $"Скачано: {CalcMemoryMensurableUnit(e.ReceivedBytesSize)}";
            UCServerCreateViewModel.UpdTotalBytesRecivedInfo.Value = $"Осталось: {CalcMemoryMensurableUnit(e.TotalBytesToReceive)}";
        }

        public static void OnStopUpdateInfo()
        {
            UCServerCreateViewModel.DowloadPersents.Value = 0;
            UCServerCreateViewModel.ProgressPersentage.Value = "";

            UCServerCreateViewModel.UpdSpeedInfo.Value = "Скорость:";
            UCServerCreateViewModel.UpdBytesRecivedInfo.Value = "Скачано:";
            UCServerCreateViewModel.UpdTotalBytesRecivedInfo.Value = "Осталось:";
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
