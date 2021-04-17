using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ServerCreation.ViewModels;

namespace ServerCreation.Views
{
    public class UCSeverCreate : UserControl
    {
        public UCSeverCreate()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            DataContext = new UCServerCreateViewModel();
        }
    }
}
