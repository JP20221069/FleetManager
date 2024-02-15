using FleetManagerCommon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagerServer.Utils
{
    public class Client
    {
        public Socket Socket { get; set; }
        public string IP { get; set; }
        public int TID { get; set; }

        public Korisnik user { get; set; }

        public Client(Socket s,string ip,int tid)
        {
            this.IP = ip;
            this.Socket = s;
            this.TID = tid;
        }
    }
}
