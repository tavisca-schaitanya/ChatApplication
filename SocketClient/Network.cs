using System.Net.Sockets;

namespace SocketClient
{
    public class Network {

        private User _user;

        private string _targetIPAddress;
        public Socket ClientSocket { get; set; }

        private NetworkClient _networkClient;

        public Network(User user)
        {
            _user = user;
            _networkClient = new NetworkClient(_user);
        }

        public void SetTargetIPAddress(string targetIPAddress)
        {
            _targetIPAddress = targetIPAddress;
        }

        public void EstablishConnection()
        {
            ClientSocket = _networkClient.GetConnectionSocket();
        }
    }
}
