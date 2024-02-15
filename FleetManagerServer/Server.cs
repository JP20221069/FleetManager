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
        public static List<Client> active_clients;
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

                        Client c = new Client(cs, cs.LocalEndPoint.ToString(), -1);
                        ClientHandler handler = new ClientHandler();
                        Thread ct = new Thread(handler.HandleRequest);
                        c.TID = ct.ManagedThreadId;
                        handler.client = c;
                        handler.InitHandler();
                        ct.Start();
                        active_clients.Add(c);
                        Logger.LogEvent(new LogEvent(EventType.Info, "Successfully connected.", c));
                    }
                    else
                    {
                        Logger.LogEvent(new LogEvent(EventType.Warning, "Unable to connect more clients.", null,true));
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
    }
}
