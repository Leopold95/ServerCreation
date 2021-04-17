using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

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
        }
    }
}
