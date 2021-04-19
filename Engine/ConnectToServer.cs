using ServerCreation.ViewModels;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace ServerCreation.Engine
{
    public static class ConnectToServer
    {
        public static NetworkStream stream;

        public static async Task Connect(string address, int port, string message)
        {
           
            try
            {
                TcpClient newClient = new TcpClient() { SendTimeout = 2000, ReceiveTimeout = 2000 };

                // Соединяемся с сервером
                await newClient.ConnectAsync(address, port);
                newClient.Client.Disconnect(false);

                stream = newClient.GetStream();

                byte[] sendBytes = Encoding.UTF8.GetBytes("msg to server");
                await stream.WriteAsync(sendBytes, 0, sendBytes.Length);

                while (true)
                {
                    byte[] bytes = new byte[newClient.ReceiveBufferSize];
                    int bytesRead = await stream.ReadAsync(bytes, 0, newClient.ReceiveBufferSize);

                    // Строка, содержащая ответ от сервера
                    string returnData = Encoding.UTF8.GetString(bytes);
                    UCServerCreateViewModel.TextLogs.Value += returnData;
                }
            }
            catch(Exception ex)
            {

            }
        }   
    }
}
