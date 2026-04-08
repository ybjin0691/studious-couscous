using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClub.MyChat
{
    internal class ChatPayload
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Message {  get; set; }
        public DateTime TimeStamp { get; set; }
        public Guid MessageId { get; set; }
        public byte[] UserImage { get; set; }
    }
}
