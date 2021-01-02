using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientServerInteractionClassLibrary
{
    /// <summary>
    /// Class describing base parameters for the Client-Server interaction.
    /// </summary>
    public abstract class NetworkPoint
    {
        /// <summary>
        /// IP-address string.
        /// </summary>
        protected string ipString;

        /// <summary>
        /// The server port.
        /// </summary>
        protected int port;

        /// <summary>
        /// Contains network point with IP-Address and port of the Server.
        /// </summary>
        protected IPEndPoint ipPoint;

        /// <summary>
        /// Max buffer size for message.
        /// </summary>
        protected const uint maxBufferSize = 4096;

        /// <summary>
        /// Initialize object of the BaseParameters class.
        /// </summary>
        /// <param name="ipString">The Server IP-Address string.</param>
        /// <param name="port">The Server port.</param>
        public NetworkPoint(string ipString, int port)
        {
            this.ipString = ipString;
            this.port = port;

            ipPoint = new IPEndPoint(IPAddress.Parse(ipString), port);
        }

        /// <summary>
        /// The delegate for methods, which encodings and returns message.
        /// </summary>
        /// <param name="message">The client(server) message.</param>
        /// <returns>New encodinged message.</returns>
        public delegate string EncodingMessageHandler(string message);

        /// <summary>
        /// Event, which calls the EncodingMessage delegate.
        /// </summary>
        public event EncodingMessageHandler EncodingMessageEvent;

        /// <summary>
        /// Calls event in derived classes.
        /// </summary>
        /// <param name="message">The client(server) message.</param>
        /// <returns>New encodinged message.</returns>
        protected string CallEvent(string message)
        {
            return EncodingMessageEvent?.Invoke(message);
        }
    }
}
