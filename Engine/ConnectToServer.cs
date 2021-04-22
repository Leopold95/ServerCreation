using ServerCreation.ViewModels;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ServerCreation.Engine
{
    public class ConnectToServer
    {
        static TcpClient client;
        static byte[] buffer = new byte[512];

        

        public static void Connect(string address, int port)
        {
            try
            {
                client = new TcpClient();
                client.Connect(IPAddress.Parse(address), port);
                client.GetStream().BeginRead(buffer, 0, buffer.Length, Server_MessageRecieved, null);

                void Server_MessageRecieved(IAsyncResult ir)
                {
                    if (ir.IsCompleted)
                    {
                        try
                        {
                            var streamGeted = client.GetStream().EndRead(ir);
                            if (streamGeted > 0)
                            {
                                var temp = new byte[streamGeted];
                                Array.Copy(buffer, 0, temp, 0, streamGeted);
                                var messageGetted = Encoding.UTF8.GetString(temp);

                                UCServerCreateViewModel.TextLogs.Value += "\n" + messageGetted;
                            }

                            Array.Clear(buffer, 0, buffer.Length);
                            client.GetStream().BeginRead(buffer, 0, buffer.Length, Server_MessageRecieved, null);
                        }
                        catch (Exception exp) { UCLogsViewModel.TextLogs.Value += "\n" + exp.Message; }
                    }
                }
            }
            catch (Exception exp) { UCLogsViewModel.TextLogs.Value += "\n" + exp.Message; }
        }

        public static async Task SendMessage(string verCore)
        {
            try
            {
                var message = Encoding.UTF8.GetBytes(verCore);
                client.GetStream().Write(message, 0, message.Length);
            }
            catch (Exception exp) { UCLogsViewModel.TextLogs.Value += "\n" + exp.Message; }
        }
    }
}
