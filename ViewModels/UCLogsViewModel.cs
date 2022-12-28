using Reactive.Bindings;

namespace ServerCreation.ViewModels
{
    public class UCLogsViewModel
    {
        public static ReactiveProperty<string> TextLogs { get; set; } = new();
    }
}
