using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientServerInteractionClassLibrary;
using ClientServerInteractionClassLibrary.EncoidngTypes;

namespace ClientServerInteractionUnitTestProject
{
    [TestClass]
    public class ClientServerInteractionUnitTest
    {
        [TestMethod]
        [DataRow("127.0.0.1", 8001, "hello world!", "hello world!")]
        [DataRow("127.0.0.1", 8002, "how", "how")]
        [DataRow("127.0.0.1", 8003, "123раз", "123raz")]
        [DataRow("127.0.0.1", 8004, "Привет", "privet")]
        [DataRow("127.0.0.1", 8005, "How are you?", "how are you?")]
        public void ReciveMessage_Client_TransleteMessage(string ipString, int port, string message, string expected)
        {
            Server server = new Server(ipString, port);
            Client client = new Client("first", ipString, port);

            client.EncodingMessageEvent += ClientEncodingType.EncodingMessage;
        
            server.Run();

            client.SendMessage(message);
            server.ReciveMessages(message);
            string actual = client.ReciveMessage();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("127.0.0.1", 8016, "Hello, my friend!", "How are you?")]
        [DataRow("127.0.0.1", 8017, "How", "How")]
        [DataRow("127.0.0.1", 8018, "123qwerty", "123qwerty фывфы")]
        [DataRow("127.0.0.1", 8019, "123qwerty!", "123qwerty312123!")]
        [DataRow("127.0.0.1", 8020, "1231231фывфывфв2!", "12312312!")]
        public void ReciveMessage_Server_AddMessageToCollection_OneMessage(string ipString, int port, string firstMessage, string secondMessage)
        {
            MessageCollection messageCollection = new MessageCollection();

            Server server = new Server(ipString, port);
            Client firstClient = new Client("first", ipString, port);
            Client secondClient = new Client("second", ipString, port);

            server.EncodingMessageEvent += messageCollection.MessageHandler;
            server.Run();

            firstClient.SendMessage(firstMessage);
            server.ReciveMessages();
            
            secondClient.SendMessage(secondMessage);
            server.ReciveMessages();

            Assert.IsTrue(messageCollection[0][0] == firstMessage && messageCollection[1][0] == secondMessage);
        }

        [TestMethod]
        [DataRow("127.0.0.1", 8021, "Hello, my friend!", "How are you?")]
        [DataRow("127.0.0.1", 8022, "How", "How")]
        [DataRow("127.0.0.1", 8023, "123qwerty", "123qwerty фывфы")]
        [DataRow("127.0.0.1", 8024, "123qwerty!", "123qwerty312123!")]
        [DataRow("127.0.0.1", 8025, "1231231фывфывфв2!", "12312312!")]
        public void ReciveMessage_Server_AddMessageToCollection_TwoMessage(string ipString, int port, string firstMessage, string secondMessage)
        {
            MessageCollection messageCollection = new MessageCollection();

            Server server = new Server(ipString, port);
            Client firstClient = new Client("first", ipString, port);

            server.EncodingMessageEvent += messageCollection.MessageHandler;
            server.Run();

            firstClient.SendMessage(firstMessage);
            server.ReciveMessages();

            firstClient.SendMessage(secondMessage);
            server.ReciveMessages();

            Assert.IsTrue(messageCollection[0][0] == firstMessage && messageCollection[0][1] == secondMessage);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Impossible to run the server.")]
        [DataRow("127.0.0.1", 8011)]
        [DataRow("127.0.0.1", 8012)]
        [DataRow("127.0.0.1", 8013)]
        [DataRow("127.0.0.1", 8014)]
        [DataRow("127.0.0.1", 8015)]
        public void Run_GetException(string ipString, int port)
        {
            Server server = new Server(ipString, port);

            server.Run();
            server.Run();
        }
    }
}
