using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ServerCreation.ViewModels;

namespace ServerCreation.Views
{
    public class UCServerStarter : UserControl
    {
        public UCServerStarter()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            DataContext = new USServerStarterViewModel();
        }
    }
}
