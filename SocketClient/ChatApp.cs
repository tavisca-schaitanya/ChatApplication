namespace SocketClient
{
    public class ChatApp
    {
        User _user;
        Network _network;
        Conversation _conversation;

        public void Start()
        {
            _user = new User("Chaitanya", "127.0.0.1", 3333);
            _network = new Network(_user);
            _network.SetTargetIPAddress("127.0.0.1");
            _network.EstablishConnection();
            _conversation = new Conversation(_network.ClientSocket);
            _conversation.StartConversation();
        }
    }
}
