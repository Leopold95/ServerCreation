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



        public static async Task Connect(string address, int port, string message)
        {

        }   
    }
}
