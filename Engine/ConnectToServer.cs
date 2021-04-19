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
        public static Socket socketTcp;

        public static async Task Connect(string address, int port, string message)
        {       
            try
            {
                IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(address), port);
                socketTcp = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                var data = Encoding.UTF8.GetBytes(message); //получение данных для отправки сообщения 

                socketTcp.Connect(iPEndPoint); //Connect to socketTCP server


                SocketAsyncEventArgs args = new SocketAsyncEventArgs();
                args.SetBuffer(data, 0, data.Length);
                socketTcp.SendAsync(args); //Sand some data to server

                testc:
                //ожидание ответа от севрера
                byte[] buffer = new byte[256];
                int size = 0;
                var answer = new StringBuilder();

                do
                {
                    size = socketTcp.Receive(buffer); //Рельно полученный басты из полученного сообщения 
                    answer.Append(Encoding.UTF8.GetString(buffer, 0, size)); //из полученного обема данных форматируем одну строку 
                }
                while (socketTcp.Available > 0);

                UCServerCreateViewModel.TextLogs.Value += $"\nОтвет от сервера: {answer}";

                goto testc;
                //socketTcp.Shutdown(SocketShutdown.Both);
                //socketTcp.Close();

            }
            catch(Exception ex)
            {

            }
        }   
    }
}
