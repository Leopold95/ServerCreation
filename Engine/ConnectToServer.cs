using ServerCreation.ViewModels;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace ServerCreation.Engine
{
    public class ConnectToServer
    {
        public static TcpClient client;
        public static StreamReader streamReader;
        public static StreamWriter streamWriter;


        public ConnectToServer()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    try
                    {
                        if (client?.Connected == true)
                        {
                            var line = streamReader.ReadLine();

                            if (line != null)
                            {
                                UCServerCreateViewModel.TextLogs.Value += line + "\n";
                                }
                            else
                            {
                                client.Close();
                                UCServerCreateViewModel.TextLogs.Value += "Cjnnected error";
                            }
                            Task.Delay(100);
                        }
                    }
                    catch { }
                }
            });
        }

        public static async Task Connect(string address, int port, string message)
        {
            await Task.Factory.StartNew(() => 
            {
                try
                {
                    client = new TcpClient();
                    client.Connect(address, port);
                    streamReader = new StreamReader(client.GetStream());
                    streamWriter = new StreamWriter(client.GetStream());

                    streamWriter.AutoFlush = true;

                    streamWriter.WriteLine("Client has been connected");
                }
                catch { }
            });
        }   
    }
}
