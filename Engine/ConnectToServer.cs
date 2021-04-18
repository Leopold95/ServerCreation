using ServerCreation.ViewModels;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace ServerCreation.Engine
{
    public static class ConnectToServer
    {
        public static async Task Connect(string address, int port, string message)
        {
            TcpClient tcpClient;
            try
            {
                tcpClient = new TcpClient(address, port);
                NetworkStream stream = tcpClient.GetStream();
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);




                data = new Byte[256];
                // String to store the response ASCII representation.
                String responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
                int bytes = stream.Read(data, 0, data.Length);
                responseData = Encoding.UTF8.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);
            }
            catch(Exception ex)
            {

            }
        }   
    }
}
