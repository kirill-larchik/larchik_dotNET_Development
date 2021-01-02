using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClientServerInteractionClassLibrary.NetworkPoint;

namespace ClientServerInteractionClassLibrary.EncoidngTypes
{
    /// <summary>
    /// Class describing functionality of collection of messages.
    /// </summary>
    public class MessageCollection
    {
        /// <summary>
        /// Class describing collection of client messages.
        /// </summary>
        public class ClientMessageCollection
        {
            /// <summary>
            /// Client`s name.
            /// </summary>
            public string ClientName { get; private set; }

            List<string> messageCollection;

            /// <summary>
            /// Returns client`s message by index.
            /// </summary>
            /// <param name="index">Message`s index.</param>
            /// <returns></returns>
            public string this[int index] { get { return messageCollection[index]; } }

            /// <summary>
            /// Initialize message colection of client.
            /// </summary>
            /// <param name="clientName">Client`s name.</param>
            public ClientMessageCollection(string clientName)
            {
                ClientName = clientName;
                messageCollection = new List<string>();
            }

            /// <summary>
            /// Add new message to collection.
            /// </summary>
            /// <param name="message">Cliet`s message.</param>
            public void AddMessage(string message)
            {
                messageCollection.Add(message);
            }
        }



        List<ClientMessageCollection> clientMessages;

        /// <summary>
        /// Count of clients.
        /// </summary>
        public int Count { get { return clientMessages.Count; } }

        /// <summary>
        /// Returns message collection of client by index.
        /// </summary>
        /// <param name="index">Index of client.</param>
        /// <returns></returns>
        public ClientMessageCollection this[int index]
        {
            get
            {
                return clientMessages[index];
            }
            set
            {
                clientMessages[index] = value;
            }
        }


        /// <summary>
        /// Adds message of client to collection.
        /// </summary>
        public EncodingMessageHandler MessageHandler { get; private set; }

        /// <summary>
        /// Initialize client`s message collection. 
        /// </summary>
        public MessageCollection()
        {
            clientMessages = new List<ClientMessageCollection>();

            MessageHandler = delegate (string message)
            {
                string[] messageArray = message.Split(new string[] { "client: ", "message: ", "|" }, StringSplitOptions.None);
                
                int index = GetClientMessageCollectionIndex(messageArray[1]);
                clientMessages[index].AddMessage(messageArray[3]);

                return message;
            };
        }

        private int GetClientMessageCollectionIndex(string clientName)
        {
            // If there are no clients.
            if (Count == 0)
            {
                clientMessages.Add(new ClientMessageCollection(clientName));
                return 0;
            }

            // Get index of exists clietns.
            for (int i = 0; i < Count; i++)
            {
                if (clientMessages[i].ClientName == clientName)
                {
                    return i;
                }
            }

            // Or add a new client.
            clientMessages.Add(new ClientMessageCollection(clientName));
            return Count - 1;
        }
    }
}
