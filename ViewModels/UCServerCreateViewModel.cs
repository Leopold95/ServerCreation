using System;
using Reactive.Bindings;
using ServerCreation.Engine;
using System.Collections.ObjectModel;
using ReactiveUI;
using System.Reactive;
using ServerCreation.Commands;
using System.IO;
using ServerCreation.Engine.Json;

using ObsCollStr = System.Collections.ObjectModel.ObservableCollection<string>;
using ServerCreation.Engine.FilesManager;
using DynamicData;
using System.Linq;

namespace ServerCreation.ViewModels
{
    public class UCServerCreateViewModel
    {
        private AppSettings settings = AppSettings.GetSettings();

        private static JsonParser _parser = new();
  
        public UCServerCreateViewModel()
        {
            SetSettings();

            var v = _parser.GetPaperVersionList();
            v.Reverse();
            Versions = v;
        }
        private void SetSettings()
        {
            if (settings.IsServer == true)
            {
                IsTextLogsVisibly.Value = true;
                IsFileLocEnabled.Value = false;
                IsFileLocBtnEnebled.Value = false;
                FileLocation.Value = "";
                BtnConnectToServerVisible.Value = true;
                BtnDisconnectFromVisible.Value = true;
            }
            else if (settings.IsServer == false)
            {
                IsTextLogsVisibly.Value = false;
                IsFileLocEnabled.Value = true;
                IsFileLocBtnEnebled.Value = true;
                FileLocation.Value = Directory.GetCurrentDirectory();
                BtnConnectToServerVisible.Value = false;
                BtnDisconnectFromVisible.Value = false;
            }
        }


        public static ObservableCollection<string> Builds { get; set; } = new();
        public static string SelectedBuild { get; set; } = string.Empty;

        public ObservableCollection<string> Versions { get; set; } = new();
        private static string _selectedVersion = string.Empty;
        public static string SelectedVersion 
        {
            get { return _selectedVersion; }
            set 
            {
                Builds.Clear();
                var v = _parser.GetLastVersionBuilds(value);
                v.Reverse();
                foreach (var item in v)
                {
                    Builds.Add(item);
                }

                _selectedVersion = value; 
            }
        }

        public ObservableCollection<string> ServerCores { get; set; } = new ObservableCollection<string>() 
        {
            "Paper"
        };
        public static string SelectedCore { get; set; } = string.Empty;

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
        public ReactiveProperty<bool> BtnConnectToServerVisible { get; set; } = new();
        public ReactiveProperty<bool> BtnDisconnectFromVisible { get; set; } = new();



        //public ReactiveCommand<Unit, Unit> DowloadCommand { get; } = ReactiveUI.ReactiveCommand.Create(() => { DeligateCommands.DowloadCommand(SelectedVersion, SelectedCore, FileLocation.Value, FileName.Value); });
        public ReactiveCommand<Unit, Unit> ConnectCommand { get; } = ReactiveUI.ReactiveCommand.Create(() => { DeligateCommands.ConnectCommand(); });
        public ReactiveCommand<Unit, Unit> ChangeDowloadFolder { get; } = ReactiveUI.ReactiveCommand.Create(() => { DeligateCommands.ChangeDowloadFolder(); });
        public ReactiveCommand<Unit, Unit> DisconnectCommand { get; } = ReactiveUI.ReactiveCommand.Create(() => { DeligateCommands.Disconnect(); });

        private async void OnDowloadClicked()
        {
            DowloadSession session = new DowloadSession();
            await session.BeginDownloadTaskAsync(
                UrlGenerator.GetPaperDowload(SelectedVersion, SelectedBuild),
                $"{FileLocation}" + "\\" + FileName + ".jar"
                );
        }
    }
}
