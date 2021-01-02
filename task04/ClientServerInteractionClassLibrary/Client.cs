using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace ClientServerInteractionClassLibrary
{
    /// <summary>
    /// Class describing functionality of Client. 
    /// </summary>
    public class Client : NetworkPoint
    {
        Socket client;

        /// <summary>
        /// Name of the Client.
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// Initialize the Client object and connects to the Server.
        /// </summary>
        /// <param name="clientName">Name of the Client.</param>
        /// <param name="ipString">The Server IP-Address string.</param>
        /// <param name="port">The Server port.</param>
        public Client(string clientName, string ipString, int port)
            : base(ipString, port)
        {
            ClientName = clientName;
        }

        /// <summary>
        /// Sends the message to the Server and return answer from the Server.
        /// </summary>
        public void SendMessage(string message)
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(ipPoint);

            message = "client: " + ClientName + "| message: " + message;
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            client.Send(buffer);
        }

        /// <summary>
        /// Recives message from the Server and returns this.
        /// </summary>
        /// <returns></returns>
        public string ReciveMessage()
        {
            try
            {
                byte[] buffer = new byte[maxBufferSize];
                int size = 0;
                StringBuilder builder = new StringBuilder();

                do
                {
                    size = client.Receive(buffer);
                    builder.Append(Encoding.UTF8.GetString(buffer, 0, size));
                }
                while (client.Available > 0);

                client.Shutdown(SocketShutdown.Both);
                client.Close();

                string message = CallEvent(builder.ToString());

                return message;
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
