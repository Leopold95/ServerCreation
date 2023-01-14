using Reactive.Bindings;
using ServerCreationEngine.Engine.System;

namespace ServerCreation.ViewModels
{
    public class UCLogsViewModel : ILogger
    {
        public static ReactiveProperty<string> TextLogs { get; set; } = new();

        public static void Log(string text)
        {
            TextLogs.Value += $"{text}\n";
        }

        void ILogger.Log(string message)
        {
            Log(message);
        }
    }
}
