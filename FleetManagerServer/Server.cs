using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FleetManagerServer.Utils;
using System.Runtime.InteropServices;

namespace FleetManagerServer
{
    public class Server
    {
        Socket socket;
        public List<Client> active_clients;
        public bool Started { get; set; }
        public Server()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            active_clients = new List<Client>();
        }

        public void Start()
        {
            // IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            try
            {
                IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(ConfigurationManager.AppSettings["ip"]), int.Parse(ConfigurationManager.AppSettings["port"]));
                socket.Bind(ipe);
                socket.Listen(Convert.ToInt32(ConfigurationManager.AppSettings["iNumMaxClients"]));
                Thread thread = new Thread(AcceptClient);
                thread.Start();
                this.Started = true;
                Logger.LogEvent(new LogEvent(EventType.Info, "Server thread started successfully TID=" + thread.ManagedThreadId + ".", null, true));
            }
            catch(Exception ex)
            {
                Logger.LogEvent(new LogEvent(EventType.Error, ex.Message, null, true));
            }
        }

        public void AcceptClient()
        {
            try
            {
                while (true)
                {
                    Socket cs = socket.Accept();
                    Client c = new Client(cs, cs.LocalEndPoint.ToString(), -1);
                    ClientHandler handler = new ClientHandler();
                    Thread ct = new Thread(handler.HandleRequest);
                    c.TID = ct.ManagedThreadId;
                    handler.client = c;
                    handler.InitHandler();
                    ct.Start();
                    Logger.LogEvent(new LogEvent(EventType.Info, "Successfully connected.", c));
                }
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(ex.Message);
                Logger.LogEvent(new LogEvent(EventType.Error, "Error connecting client. "+ex.Message, null, true));
            }
        }


        public void Stop()
        {
            Logger.LogEvent(new LogEvent(EventType.Info, "Server stopped.", null, true));
            this.Started = false;
            socket.Close();
        }
    }
}
