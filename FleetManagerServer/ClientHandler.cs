using Common.Domain;
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
                    Logger.LogEvent(new LogEvent(EventType.Info, "Client " +socket.LocalEndPoint.ToString()+" disconnected.",null,true));
                    Server.active_clients.Remove(client);
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
                else if(req.Operation==Operation.AddUser)
                {
                    Korisnik k = (Korisnik)req.Argument;
                    Logger.LogEvent(new LogEvent(EventType.Info, "User " + client.user.Username + " added a record to " + k.TableName + "."));
                    Controller.Instance.AddUser(k);
                    res.Result = new FleetManagerCommon.Comms.Message(MessageType.Success);
                }
                else if(req.Operation==Operation.AddVehicle)
                {
                    Vozilo v = (Vozilo)req.Argument;
                    Logger.LogEvent(new LogEvent(EventType.Info, "User " + client.user.Username + " added a record to " + v.TableName + "."));
                    Controller.Instance.AddVehicle(v);
                    res.Result = new FleetManagerCommon.Comms.Message(MessageType.Success);
                }
                else if(req.Operation==Operation.SearchVehicle)
                {
                    Vozilo v = (Vozilo)req.Argument;
                    res.Result = Controller.Instance.SearchVehicle(v);
                }
                else if (req.Operation == Operation.GetAllVehicles)
                {
                    res.Result = Controller.Instance.GetAllVehicles();
                }
                else if(req.Operation==Operation.DeleteVehicle)
                {
                    Controller.Instance.DeleteVehicle((Vozilo)req.Argument);
                    res.Result = new FleetManagerCommon.Comms.Message(MessageType.Success);
                }
                else if(req.Operation==Operation.AlterVehicle)
                {
                    Controller.Instance.UpdateVehicle((Vozilo)req.Argument);
                    res.Result = new FleetManagerCommon.Comms.Message(MessageType.Success);
                }
            }
            catch (Exception ex)
            {
                res.Exception = ex;
                Debug.WriteLine(ex.Message);
                Logger.LogEvent(new LogEvent(EventType.Error, "Error handling client (TID: "+client.TID+" Address:"+socket.LocalEndPoint.ToString()+") : " + ex.Message,null,true));

            }
            return res;
        }
    }
}
