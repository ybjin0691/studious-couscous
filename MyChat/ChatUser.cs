using System.IO;
using System.Net.Sockets;

namespace MyClub.MyChat
{
    internal class ChatUser
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public TcpClient Client { get; set; }
        public StreamWriter Writer { get; set; }
        public StreamReader Reader { get; set; }
        //public byte[] Image { get; set; }

        public ChatUser(string userId, string userName, TcpClient client)
        {
            UserId = userId;
            UserName = userName;
            Client = client;
            //Image = image;
            
            var stream = client.GetStream();
            Writer = new StreamWriter(stream) { AutoFlush = true };
            Reader = new StreamReader(stream);
        }
    }
}
