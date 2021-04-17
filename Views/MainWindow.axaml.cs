using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ServerCreation.Engine;
using ServerCreation.ViewModels;
using System.Diagnostics;

namespace ServerCreation.Views
{
    public class MainWindow : Window
    {
        private ContentControl contentControl;

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            DataContext = new MainWindowViewModel();
            contentControl = this.FindControl<ContentControl>("contentControl");
        }

        public void ChangeServerClick(object sender, RoutedEventArgs args)
        {       
            contentControl.Content = new UCSeverCreate();
            DataContext = contentControl;
        }

        public void OnBtnOptionsClick(object sender, RoutedEventArgs args)
        {
            contentControl.Content = new UCOptions();
            DataContext = contentControl;
            
        }

        public void ServerStarter_CLick(object sender, RoutedEventArgs args)
        {
            contentControl.Content = new UCServerStarter();
            DataContext = contentControl;
        }

        public void OnButtonLogsClick()
        {
            contentControl.Content = new UCLogs();
            DataContext = contentControl;
        }


    }
}
