using Avalonia.Controls;
using ServerCreation.ViewModels;
using ServerCreation.Views;

namespace ServerCreation.Commands
{
    public class OptionsCommands
    {
        public static async void ChangeJavaLocationFolderCommand()
        {
            MainWindow? mv = MainWindow.MainWindowPtr;

            OpenFolderDialog openFolderDialog = new OpenFolderDialog();
            openFolderDialog.Title = "Укажите путь к Java";

            UCOptionsViewModel.JavaFolder.Value = string.Join("", await openFolderDialog.ShowAsync(mv));
        }
    }
}
