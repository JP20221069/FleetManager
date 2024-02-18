using FleetManagerServer.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FleetManagerCommon.Domain;
using FleetManagerServer.SysOps;
using Common.Domain;

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

        public void AddUser(Korisnik user)
        {
            AddUserSO so = new AddUserSO(user);
            so.ExecuteTemplate();
        }

        public void AddVehicle(Vozilo veh)
        {
            AddVehicleSO so = new AddVehicleSO(veh);
            so.ExecuteTemplate();
        }

        public List<Vozilo> SearchVehicle(Vozilo veh)
        {
            SearchVehicleSO so = new SearchVehicleSO(veh);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Vozilo> GetAllVehicles()
        {
            GetAllVehiclesSO so = new GetAllVehiclesSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        public void UpdateVehicle(Vozilo veh)
        {
            UpdateVehicleSO so = new UpdateVehicleSO(veh);
            so.ExecuteTemplate();
        }

        public void DeleteVehicle(Vozilo veh)
        {
            DeleteVehicleSO so = new DeleteVehicleSO(veh);
            so.ExecuteTemplate();
        }
    }
}
