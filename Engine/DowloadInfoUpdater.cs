using Downloader;
using Newtonsoft.Json;
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
        //If Server is not using
        public static void OnNewUpdateInfo(DownloadProgressChangedEventArgs e)
        {
            UCServerCreateViewModel.DowloadPersents.Value = Convert.ToInt32(e.ProgressPercentage);
            UCServerCreateViewModel.ProgressPersentage.Value = Convert.ToUInt32(e.ProgressPercentage) + "%";

            UCServerCreateViewModel.UpdSpeedInfo.Value = $"Скорость: {CalcMemoryMensurableUnit(e.BytesPerSecondSpeed)}/s";
            UCServerCreateViewModel.UpdBytesRecivedInfo.Value = $"Скачано: {CalcMemoryMensurableUnit(e.ReceivedBytesSize)}";
            UCServerCreateViewModel.UpdTotalBytesRecivedInfo.Value = $"Осталось: {CalcMemoryMensurableUnit(e.TotalBytesToReceive)}";
        }
        public static void OnStopUpdateInfo()
        {
            UCLogsViewModel.TextLogs.Value += "\nDowload comlited";
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


        //Is server using
        public static void OnNewDowloadInfoInServer(string json)
        {
            JsonCreator jsonCreator = JsonConvert.DeserializeObject<JsonCreator>(json);

            UCServerCreateViewModel.DowloadPersents.Value = Convert.ToInt32(jsonCreator.Progress);
            UCServerCreateViewModel.ProgressPersentage.Value = jsonCreator.Progress;
            UCServerCreateViewModel.UpdSpeedInfo.Value = $"Скорость: {jsonCreator.Speed}/s";
            UCServerCreateViewModel.UpdBytesRecivedInfo.Value = $"Скачано: {jsonCreator.Recieved}";
            UCServerCreateViewModel.UpdTotalBytesRecivedInfo.Value = $"Осталось: {jsonCreator.TotalToRecirve}";
        }
        public static void OnDowloadComplitedOnServer()
        {
            UCServerCreateViewModel.DowloadPersents.Value = 0;
            UCServerCreateViewModel.ProgressPersentage.Value = "";
            UCServerCreateViewModel.UpdSpeedInfo.Value = $"Скорость: ";
            UCServerCreateViewModel.UpdBytesRecivedInfo.Value = $"Скачано: ";
            UCServerCreateViewModel.UpdTotalBytesRecivedInfo.Value = $"Осталось: ";
        }
    }
}
