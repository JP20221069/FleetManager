using FleetManagerCommon.Comms;
using FleetManagerCommon.Communication;
using FleetManagerCommon.Domain;
using FleetManagerServer.SysOps;
using FleetManagerServer.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetManagerServer
{
    public class ClientHandler
    {
        private Sender sender;
        private Receiver receiver;
        private Socket socket;
        public Client client { get; set; }
        private bool flag_disconnect = false;

        public ClientHandler()
        {
            
        }
        public ClientHandler(Socket socket)
        {
            this.socket = socket;
            sender = new Sender(socket);
            receiver = new Receiver(socket);
        }
        public ClientHandler(Client client)
        {
            this.client = client;
            this.socket =client.Socket;
            sender = new Sender(socket);
            receiver = new Receiver(socket);
        }

        public void InitHandler()
        {
            this.socket=client.Socket;
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
                if(flag_disconnect==true)
                {
                    Logger.LogEvent(new LogEvent(EventType.Info, "Client disconnected."));
                    receiver.Stop();
                    socket.Close();
                    break;
                }
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
                        client.user = k;
                        Logger.LogEvent(new LogEvent(EventType.Info, "User " + k.Username + " successfully logged in.",client));
                        res.Result = k;
                    }
                }
                else if(req.Operation==Operation.Logout)
                {
                    Korisnik k = (Korisnik)req.Argument;
                    if(k!=null)
                    {
                        Logger.LogEvent(new LogEvent(EventType.Info, "User " + k.Username + " logged out.", client));
                        Controller.Instance.Logout(k);
                    }
                }
                else if(req.Operation==Operation.Disconnect)
                {
                    //res.Result = new Message(MessageType.Success);
                    flag_disconnect = true;
                }
            }
            catch (Exception ex)
            {
                res.Exception = ex;
                Debug.WriteLine(ex.Message);
                Logger.LogEvent(new LogEvent(EventType.Error, "Erorr handling client: " + ex.Message));

            }
            return res;
        }
    }
}
