using Reactive.Bindings;
using ReactiveUI;
using ServerCreation.Commands;
using ServerCreation.Engine;
using System.Reactive;

namespace ServerCreation.ViewModels
{
    public class UCOptionsViewModel : ViewModelBase
    {
        public UCOptionsViewModel()
        {
            //Подгрузка параетров из настроек
            IsChecked.Value = stg.IsServer;
            PortText.Value = stg.ServerPort;
            IpText.Value = stg.ServerIp;
        }

        AppSettings settings = new AppSettings();
        AppSettings stg = AppSettings.GetSettings();

        public static ReactiveProperty<bool> IsChecked { get; set; } = new();
        public ReactiveProperty<int> PortText { get; set; } = new();
        public ReactiveProperty<string> IpText { get; set; } = new();
        public static ReactiveProperty<string> JavaFolder { get; set; } = new();

        public ReactiveCommand<Unit, Unit> ChangeJavaFolderCommand { get; } = ReactiveUI.ReactiveCommand.Create(() => { DeligateCommands.ChangeJavaLocationFolderCommand(); });

        public void SaveCommand()
        {
            settings.IsServer = IsChecked.Value;
            settings.ServerIp = IpText.Value;
            settings.ServerPort = PortText.Value;

            settings.Save();
        }
        public void CancelCommand()
        {
            IsChecked.Value = stg.IsServer;
            PortText.Value = stg.ServerPort;
            IpText.Value = stg.ServerIp;
        }
        public void DefaultCommand()
        {
            IsChecked.Value = false;
            PortText.Value = 8888;
            IpText.Value = "127.0.0.1";
        }
    }
}
