using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientServerInteractionClassLibrary
{
    /// <summary>
    /// Class describing functionality of Server.
    /// </summary>
    public class Server : NetworkPoint
    {
        Socket listenSocket;
        Socket client;

        bool CanRun { get; set; }

        /// <summary>
        /// Initialize the Server object.
        /// </summary>
        /// <param name="ipString">The Server IP-Address string.</param>
        /// <param name="port">The Server port.</param>
        public Server(string ipString, int port)
            : base(ipString, port)
        {
            CanRun = true;
        }

        /// <summary>
        /// Runs the Server.
        /// </summary>
        public void Run()
        {
            if (CanRun)
            {
                listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                listenSocket.Bind(ipPoint);
                listenSocket.Listen(1);

                CanRun = false;
            }
            else
                throw new Exception("Impossible to run the server.");
        }

        /// <summary>
        /// Recives messages form clients and send answer to clients. Also returns the client message.
        /// </summary>
        /// <param name="answer">The message of the server, which will be sented to the client.</param>
        /// <returns>The client message.</returns>
        public string ReciveMessages(string answer = "Your message is succesful sended.")
        {
            try
            {
                client = listenSocket.Accept();

                int size = 0;
                byte[] buffer = new byte[maxBufferSize];
                StringBuilder builder = new StringBuilder();

                do
                {
                    size = client.Receive(buffer);
                    builder.Append(Encoding.UTF8.GetString(buffer, 0, size));
                }
                while (client.Available > 0);

                CallEvent(builder.ToString());

                buffer = Encoding.UTF8.GetBytes(answer);
                client.Send(buffer);

                client.Shutdown(SocketShutdown.Both);
                client.Close();

                return builder.ToString();
            }
            catch
            {
                client.Shutdown(SocketShutdown.Both);
                client.Close();

                throw new Exception("An error occurred while receiving the message.");
            }
        }
    }
}
