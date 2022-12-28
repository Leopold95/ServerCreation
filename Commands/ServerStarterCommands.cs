using ServerCreation.Engine;
using ServerCreation.ViewModels;
using System;

namespace ServerCreation.Commands
{
    public class ServerStarterCommands
    {
        public static void SendCommandToServer()
        {
            try
            {
                USServerStarterViewModel.TextIn.Value += $"\n{USServerStarterViewModel.TextOut.Value}";

                ServersRemouter.streamWr.WriteLine(USServerStarterViewModel.TextOut.Value);
            }
            catch (Exception exp)
            {
                USServerStarterViewModel.TextIn.Value += $"\n{exp.Message}";
            }
        }
        public static void StartServer()
        {
            ServersRemouter sm = new();
            sm.StartServer();

            USServerStarterViewModel.TextIn.Value += Environment.OSVersion.Platform;
        }
    }
}
