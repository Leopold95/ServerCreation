using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ServerCreation.ViewModels;

namespace ServerCreation.Views
{
    public class UCOptions : UserControl
    {


        public UCOptions()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            DataContext = new UCOptionsViewModel();
        }
    }
}
