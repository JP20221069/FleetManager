using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagerCommon.Comms
{
    [Serializable]
    public class Message
    {
        public string Text { get; set; }
        public MessageType MessageType { get; set; }

        public Message()
        {
            
        }

        public Message(MessageType type , string text="")
        {
            this.MessageType = type;
            this.Text = text;
        }
    }
}
