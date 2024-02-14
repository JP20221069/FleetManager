using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
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
            socket.Connect("127.0.0.1", 2555);
            sender = new Sender(socket);
            receiver = new Receiver(socket);
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

        /*internal Response CreatePerson(Person person)
        {
            Request request = new Request
            {
                Argument = person,
                Operation = Operation.CreatePerson
            };
            sender.Send(request);
            Response response = (Response)receiver.Receive();
            return response;
        }*/

       /* internal object GetAllCity()
        {
            Request request = new Request
            {
                Operation = Operation.GetAllCity
            };
            sender.Send(request);
            Response response = (Response)receiver.Receive();
            return response.Result;

        }*/

    }
}
