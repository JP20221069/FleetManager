﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Common.Comms
{
    public class Message
    {
        public string Text { get; set; }
        public MessageType MessageType { get; set; }
    }
}
