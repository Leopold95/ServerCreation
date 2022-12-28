using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ServerCreation.ViewModels;
using System.Diagnostics;
using System.Threading;

namespace ServerCreation.Views
{
    public class UCLogs : UserControl
    {
        private Thread? _updateThread;

        public UCLogs()
        {
            InitializeComponent();
            _updateThread = new(UpdateLoop);
            _updateThread.Start();
        }

        ~UCLogs()
        {
            _updateThread.Abort();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            DataContext = new UCLogsViewModel();
        }

        private void UpdateLoop()
        {
            while(true)
            {
               

                Thread.Sleep(100);
            }
        }
    }
}
