using Reactive.Bindings;
using ServerCreation.Engine;
using System.Collections.ObjectModel;
using ReactiveUI;
using System.Reactive;
using ServerCreation.Commands;
using System.IO;
using Avalonia.Controls;

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
                IsServerDowloaderVisible.Value = false;
            }
            else if (settings.IsServer == false)
            {
                IsTextLogsVisibly.Value = false;
                IsServerDowloaderVisible.Value = true;
            }
        }
      
        public ObservableCollection<string> Versions { get; set; } = new ObservableCollection<string>()
        { 
            "1.16.5", "1.12.2", ""
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
    }
}
