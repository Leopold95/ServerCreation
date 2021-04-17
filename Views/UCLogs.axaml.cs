using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ServerCreation.ViewModels;

namespace ServerCreation.Views
{
    public class UCLogs : UserControl
    {
        public UCLogs()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            DataContext = new UCLogsViewModel();
        }
    }
}
