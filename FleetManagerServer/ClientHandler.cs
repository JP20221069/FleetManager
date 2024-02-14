using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagerServer
{
    public class ClientHandler
    {
        private Sender sender;
        private Receiver receiver;
        private Socket socket;

        public ClientHandler(Socket socket)
        {
            this.socket = socket;
            sender = new Sender(socket);
            receiver = new Receiver(socket);
        }

        public void HandleRequest()
        {
            while (true)
            {
                Request req = (Request)receiver.Receive();
                Response res = ProcessRequest(req);
                sender.Send(res);
            }
        }

        private Response ProcessRequest(Request req)
        {
            Response res = new Response();
            try
            {
                if(req.Operation==Operation.Login)
                {
                    Korisnik k = Controller.Instance.Login((Korisnik)req.Argument);
                    if(k != null) 
                    {
                        res.Result = k;
                    }
                }
            }
            catch (Exception ex)
            {
                res.Exception = ex;
                Debug.WriteLine(ex.Message);
            }
            return res;
        }
    }
}
