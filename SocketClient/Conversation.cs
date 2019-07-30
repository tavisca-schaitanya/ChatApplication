using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SocketClient
{
    public class Conversation
    {
        private Socket _clientSocket;
        public Conversation(Socket clientSocket)
        {
            _clientSocket = clientSocket;
        }

        private void ReadMessages(Socket handler)
        {
            string data = null;
            byte[] bytes = null;

            while (true)
            {
                bytes = new byte[1024];
                int bytesRec = handler.Receive(bytes);
                data = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                Console.WriteLine("> {0}", data);
            }
        }


        private void WriteMessages(Socket sender)
        {
            while (true)
            {
                string message = Console.ReadLine();
                byte[] msg = Encoding.ASCII.GetBytes(message);
                int bytesSent = sender.Send(msg);
            }
        }

        public void StartConversation()
        {
            Thread threadWrite = new Thread(() => WriteMessages(_clientSocket));
            Thread threadRead = new Thread(() => ReadMessages(_clientSocket));
            threadWrite.Start();
            threadRead.Start();
        }

        public void EndConversation()
        {
            _clientSocket.Shutdown(SocketShutdown.Both);
        }

    }
}
