using Reactive.Bindings;
using ServerCreation.Engine;
using System.Collections.ObjectModel;
using ReactiveUI;
using System.Reactive;
using ServerCreation.Commands;
using System.IO;

namespace ServerCreation.ViewModels
{
    public class UCServerCreateViewModel
    {
        AppSettings settings = AppSettings.GetSettings();

  
        public UCServerCreateViewModel()
        {
            SetSettings();
        }
        private void SetSettings()
        {
            if (settings.IsServer == true)
            {
                IsTextLogsVisibly.Value = true;
                IsFileLocEnabled.Value = false;
                IsFileLocBtnEnebled.Value = false;
                FileLocation.Value = "";

            }
            else if (settings.IsServer == false)
            {
                IsTextLogsVisibly.Value = false;
                IsFileLocEnabled.Value = true;
                IsFileLocBtnEnebled.Value = true;
                FileLocation.Value = Directory.GetCurrentDirectory();
            }
        }


        public ObservableCollection<string> Versions { get; set; } = new ObservableCollection<string>()
        { 
            "1.7.10", "1.8.8", "1.9.4", "1.10.2", "1.11.2", "1.12.2", "1.13.2", "1.14.4", "1.15.2", "1.16.5"
        };
        public static string SelectedVersion { get; set; }
        public ObservableCollection<string> ServerCores { get; set; } = new ObservableCollection<string>() 
        {
            "Vanilla", "Bukkit", "Spigot", "Paper", "Forge", "CatServer"
        };
        public static string SelectedCore { get; set; }
        static public ReactiveProperty<string> TextLogs { get; set; } = new();
        public ReactiveProperty<bool> IsTextLogsVisibly { get; set; } = new();
        public ReactiveProperty<bool> IsServerDowloaderVisible { get; set; } = new();
        public static ReactiveProperty<string> FileLocation { get; set; } = new();
        public static ReactiveProperty<string> FileName { get; set; } = new("server");
        public static ReactiveProperty<int> DowloadPersents { get; set; } = new();
        public ReactiveProperty<bool> IsFileLocEnabled { get; set; } = new();
        public ReactiveProperty<bool> IsFileLocBtnEnebled { get; set; } = new();
        public static ReactiveProperty<string> ProgressPersentage { get; set; } = new();
        public static ReactiveProperty<string> DowloadInfo { get; set; } = new();

        public static ReactiveProperty<string> UpdSpeedInfo { get; set; } = new();
        public static ReactiveProperty<string> UpdBytesRecivedInfo { get; set; } = new();
        public static ReactiveProperty<string> UpdTotalBytesRecivedInfo { get; set; } = new();



        public ReactiveCommand<Unit, Unit> DowloadCommand { get; } = ReactiveUI.ReactiveCommand.Create(() => { DeligateCommands.DowloadCommand(SelectedVersion, SelectedCore, FileLocation.Value, FileName.Value); });
        public ReactiveCommand<Unit, Unit> ConnectCommand { get; } = ReactiveUI.ReactiveCommand.Create(() => { DeligateCommands.ConnectCommand(); });
        public ReactiveCommand<Unit, Unit> ChangeDowloadFolder { get; } = ReactiveUI.ReactiveCommand.Create(() => { DeligateCommands.ChangeDowloadFolder(); });
    }
}
