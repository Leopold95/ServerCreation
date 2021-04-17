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
            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // подключаемся к удаленному хосту
                await socket.ConnectAsync(ipPoint);

                byte[] data = Encoding.Unicode.GetBytes(message);

                SocketAsyncEventArgs e = new SocketAsyncEventArgs();
                e.SetBuffer(data, 0, data.Length);

                socket.SendAsync(e);

                // получаем ответ
                data = new byte[1024]; // буфер для ответа
                StringBuilder builder = new StringBuilder();
                int bytes = 0; // количество полученных байт

                do
                {
                    bytes = socket.Receive(data, data.Length, 0);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (socket.Available > 0);

                UCServerCreateViewModel.TextLogs.Value += $"\nответ сервера: {builder}";

                // закрываем сокет
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception ex)
            {
                UCServerCreateViewModel.TextLogs.Value = $"{ex.Message}";
            }
        }
    }
}
