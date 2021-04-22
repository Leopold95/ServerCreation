using Reactive.Bindings;
using ServerCreation.Engine;
using System.Collections.ObjectModel;
using ReactiveUI;
using System.Reactive;
using ServerCreation.Commands;
using System.IO;
using System.Text;
using System.Threading;
using System;
using System.Threading.Tasks;

namespace ServerCreation.ViewModels
{
    public class UCServerCreateViewModel : ViewModelBase
    {
        AppSettings settings = AppSettings.GetSettings();

  
        public UCServerCreateViewModel()
        {
            if (settings.IsServer == true)
            {
                IsTextLogsVisibly.Value = true;
                IsServerDowloaderVisible.Value = true;
            }
            else if (settings.IsServer == false)
            {
                IsTextLogsVisibly.Value = false;
                IsServerDowloaderVisible.Value = true;
            }
        }


        public ObservableCollection<string> Versions { get; set; } = new ObservableCollection<string>()
        { 
            "1.7.10", "1.8.8", "1.9.4", "1.10.2", "1.11.2", "1.12.2", "1.13.2", "1.14.4", "1.15.2", "1.16.5"
        };
        public static string SelectedVersion { get; set; }
        public ObservableCollection<string> ServerCores { get; set; } = new ObservableCollection<string>() 
        {
            "Vanilla", "Bukkit", "Spigot (1.12.2)", "Paper", "Forge", "CatServer"
        };
        public static string SelectedCore { get; set; }
        static public ReactiveProperty<string> TextLogs { get; set; } = new();
        public ReactiveProperty<bool> IsTextLogsVisibly { get; set; } = new();
        public ReactiveProperty<bool> IsServerDowloaderVisible { get; set; } = new();
        public static ReactiveProperty<string> FileLocation { get; set; } = new(Directory.GetCurrentDirectory());
        public static ReactiveProperty<string> FileName { get; set; } = new("server");
        public static ReactiveProperty<int> DowloadPersents { get; set; } = new();

        public ReactiveCommand<Unit, Unit> DowloadCommand { get; } = ReactiveUI.ReactiveCommand.Create(() => { DeligateCommands.DowloadCommand(SelectedVersion, SelectedCore, FileLocation.Value, FileName.Value); });
        public ReactiveCommand<Unit, Unit> ChangeDowloadFolder { get; } = ReactiveUI.ReactiveCommand.Create(() => { DeligateCommands.ChangeDowloadFolder(); });


        public void ConnectCommnd()
        {
            ConnectToServer.Connect("127.0.0.1", 8888);
        }

        public async void ConnectCommnd2()
        {
            await ConnectToServer.SendMessage("");
        }
    }
}
