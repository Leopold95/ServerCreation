using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ServerCreation.ViewModels;

namespace ServerCreation.Views
{
    public class MainWindow : Window
    {
        private ContentControl? contentControl;
        public static MainWindow? MainWindowPtr { get; private set; }

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
            MainWindowPtr = this;
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

        public void OnButtonLogsClick(object sender, RoutedEventArgs args)
        {
            contentControl.Content = new UCLogs();
            DataContext = contentControl;
        }
    }
}
