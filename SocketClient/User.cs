using System.Net;

namespace SocketClient
{
    public class User
    {
        private string _userName;
        private IPAddress _iPAddress;
        private IPEndPoint _iPEndPoint;

        public User(string userName, string iPAddress, int portNumber)
        {
            _userName = userName;
            _iPAddress = IPAddress.Parse(iPAddress);
            _iPEndPoint = new IPEndPoint(_iPAddress, portNumber);

        }

        public IPAddress GetIPAddress()
        {
            return _iPAddress;
        }


        public IPEndPoint GetIPEndPoint()
        {
            return _iPEndPoint;
        }

    }
}
