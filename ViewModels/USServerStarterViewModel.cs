using Reactive.Bindings;
using ReactiveUI;
using ServerCreation.Commands;
using System.Reactive;

namespace ServerCreation.ViewModels
{
    public class USServerStarterViewModel
    {
        public static ReactiveProperty<string> TextIn { get; set; } = new();
        public static ReactiveProperty<string> TextOut { get; set; } = new();

        public ReactiveCommand<Unit, Unit> Send { get; } = ReactiveUI.ReactiveCommand.Create(() => { DeligateCommands.SendCommandToServer(); });
        public ReactiveCommand<Unit, Unit> TestCommand { get; } = ReactiveUI.ReactiveCommand.Create(() => { DeligateCommands.StartServer(); });
    }
}
