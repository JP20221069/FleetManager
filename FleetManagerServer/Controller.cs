using FleetManagerServer.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FleetManagerCommon.Domain;
using FleetManagerServer.SysOps;

namespace FleetManagerServer
{
    public class Controller
    {
        private DatabaseBroker broker;

        private static Controller instance;
        public static Controller Instance
        {
            get
            {
                if (instance == null) instance = new Controller();
                return instance;
            }
        }
        private Controller() { broker = new DatabaseBroker(); }

        public Korisnik Login(Korisnik user)
        {
            LoginSO so = new LoginSO(user);
            so.ExecuteTemplate();
            return so.Result;

        }

        public void Logout(Korisnik user)
        {
            LogoutSO so = new LogoutSO(user);
            so.ExecuteTemplate();
        }

        public Korisnik AddUser(Korisnik user)
        {
            AddUserSO so = new AddUserSO(user);
            so.ExecuteTemplate();
            return so.Result;
        }

    }
}
