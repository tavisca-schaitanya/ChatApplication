using System;
using System.Net.Sockets;

namespace SocketClient
{
    public class NetworkClient
    {
        private User _user;

        public NetworkClient(User user)
        {
            _user = user;
        }
        public Socket RequestConnection()
        {
            Socket sender = new Socket(_user.GetIPAddress().AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            sender.Connect(_user.GetIPEndPoint());
            return sender;
        }


        public Socket InitiateConnection()
        {
            Socket sender = new Socket(_user.GetIPAddress().AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            sender.Bind(_user.GetIPEndPoint());
            sender.Listen(10);
            return sender.Accept();
        }

        public Socket GetConnectionSocket()
        {
            Socket clientSocket;
            try
            {
                clientSocket = RequestConnection();
            }
            catch (Exception)
            {
                clientSocket = InitiateConnection();
            }
            return clientSocket;
        }
    }
}
