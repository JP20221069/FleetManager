﻿using Common.Domain;
using Common.Exceptions;
using FleetManager.Controls;
using FleetManagerCommon.Comms;
using FleetManagerCommon.Communication;
using FleetManagerCommon.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.Comms
{
    public class CommunicationManager
    {

        private static CommunicationManager instance;
        public static CommunicationManager Instance
        {
            get
            {
                if (instance == null) instance = new CommunicationManager();
                return instance;
            }
        }
        private CommunicationManager()
        {

        }

        Socket socket;
        Sender sender;
        Receiver receiver;

        public void Connect()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ConfigurationManager.AppSettings["server_ip"], Convert.ToInt32(ConfigurationManager.AppSettings["server_port"]));
            sender = new Sender(socket);
            receiver = new Receiver(socket);
            Response res = (Response)receiver.Receive();
            if(res.Exception!=null)
            {
                throw res.Exception;
            }

        }

        internal Response Login(Korisnik user)
        {
            Request req = new Request
            {
                Argument = user,
                Operation = Operation.Login
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal void Disconnect()
        {
            Request req = new Request
            {
                Argument = null,
                Operation = Operation.Disconnect
            };
            sender.Send(req);
        }

        internal Response Logout(Korisnik current_user)
        {
            Request req = new Request
            {
                Argument = current_user,
                Operation = Operation.Logout
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal Response AddUser(Korisnik user)
        {
            Request req = new Request
            {
                Argument = user,
                Operation = Operation.AddUser
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal Response AddVehicle(Vozilo veh)
        {
            Request req = new Request
            {
                Argument = veh,
                Operation = Operation.AddVehicle
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal Response SearchVehicle(Vozilo veh)
        {
            Request req = new Request
            {
                Argument = veh,
                Operation = Operation.SearchVehicle
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal Response GetAllVehicles()
        {
            Request req = new Request
            {
                Argument = null,
                Operation = Operation.GetAllVehicles
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }
        internal Response DeleteVehicle(Vozilo veh)
        {
            Request req = new Request
            {
                Argument = veh,
                Operation = Operation.DeleteVehicle
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal Response AlterVehicle(Vozilo veh)
        {
            Request req = new Request
            {
                Argument = veh,
                Operation = Operation.AlterVehicle
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal Response GetFreeVehicles()
        {
            Request req = new Request
            {
                Argument = null,
                Operation = Operation.GetFreeVehicles
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal Response GetUserCheckins(Korisnik user)
        {
            Request req = new Request
            {
                Argument = user,
                Operation = Operation.GetCheckinsByUser
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal Response CheckinVehicle(Zaduzenje chk_in)
        {
            Request req = new Request
            {
                Argument = chk_in,
                Operation = Operation.CheckinVehicle
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal Response CheckoutVehicle(Zaduzenje chk_out)
        {
            Request req = new Request
            {
                Argument = chk_out,
                Operation = Operation.CheckoutVehicle
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal Response GetAllServices()
        {
            Request req = new Request
            {
                Argument = null,
                Operation = Operation.GetAllServices
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal Response ServiceVehicle(Servisiranje s)
        {
            Request req = new Request
            {
                Argument = s,
                Operation = Operation.ServiceVehicle
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal Response GetAllUsers()
        {
            Request req = new Request
            {
                Argument = null,
                Operation = Operation.GetAllUsers
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal Response AlterUser(Korisnik k)
        {
            Request req = new Request
            {
                Argument = k,
                Operation = Operation.UpdateUser
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal Response SearchUser(Korisnik k)
        {
            Request req = new Request
            {
                Argument = k,
                Operation = Operation.SearchUsers
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal bool SocketConnected()
        {
            bool part1 = sender.socket.Poll(100,SelectMode.SelectError);
            bool part2 = (sender.socket.Available == 0);
            if (part1 && part2)
                return false;
            else
                return true;
        }
    }
}
