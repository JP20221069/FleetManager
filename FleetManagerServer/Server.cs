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
using FleetManagerServer.GuiController;
using FleetManagerCommon.Communication;
using System.Xml.Linq;
using Common.Exceptions;
using FleetManagerCommon.Comms;

namespace FleetManagerServer
{
    public class Server
    {
        Socket socket;
        public static List<Client> active_clients;
        public static List<ClientHandler> active_handlers;
        int max_clients;
        string ip;
        int port;

        public bool Started { get; set; }
        public int ClientCount { get { return Server.active_clients.Count; } }
        public int MaxClients { get { return this.max_clients; } }
        public string IP { get { return this.ip; } set { this.ip = value; } }
        public int Port { get { return this.port; } set { this.port = value; } }

        public Server()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            active_clients = new List<Client>();
            active_handlers = new List<ClientHandler>();
            max_clients = Convert.ToInt32(ConfigurationManager.AppSettings["iNumMaxClients"]);
            ip= ConfigurationManager.AppSettings["server_ip"];
            port = Convert.ToInt32(ConfigurationManager.AppSettings["server_port"]);
        }

        public void Start()
        {
            // IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            try
            {
                Logger.Start();
                IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(ip),port);
                socket.Bind(ipe);
                socket.Listen(max_clients);
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
                    if (active_clients.Count < max_clients)
                    {
                        Sender s = new Sender(cs);
                        Response res = new Response();
                        res.Result = new Message(MessageType.Success);
                        s.Send(res);
                        Client c = new Client(cs, cs.LocalEndPoint.ToString(), -1);
                        ClientHandler handler = new ClientHandler();
                        Thread ct = new Thread(handler.HandleRequest);
                        c.TID = ct.ManagedThreadId;
                        handler.client = c;
                        handler.InitHandler();
                        ct.Start();
                        active_clients.Add(c);
                        active_handlers.Add(handler);
                        Logger.LogEvent(new LogEvent(EventType.Info, "Successfully connected.", c));
                    }
                    else
                    {
                        Logger.LogEvent(new LogEvent(EventType.Warning, "Unable to connect more clients.", null,true));
                        Sender s = new Sender(cs);
                        Response res = new Response();
                        res.Exception = new ClientLimitException();
                        s.Send(res);
                        cs.Disconnect(false);
                    }
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
            Logger.Stop();
            this.Started = false;
            socket.Close();
        }

        public void StopAndDisconnect()
        {
            Request logout = new Request();
            logout.Operation = Operation.Logout;
            Request disconnect = new Request();
            disconnect.Operation = Operation.Disconnect;
            foreach(ClientHandler name in active_handlers)
            {
                logout.Argument = name.client.user;
                name.ProcessRequest(logout);
                name.ProcessRequest(disconnect);
            }
            active_handlers.Clear();
            Logger.LogEvent(new LogEvent(EventType.Info, "Server stopped.", null, true));
            Logger.Stop();
            this.Started = false;
            socket.Close();
        }

        public void DisconnectAll()
        {
            Request req = new Request();
            req.Operation = Operation.Logout;
            foreach (ClientHandler name in active_handlers)
            {
                name.ProcessRequest(req);
                active_handlers.Remove(name);
            }
        }
    }
}
