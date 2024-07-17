using FleetManagerServer.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FleetManagerCommon.Domain;
using FleetManagerServer.SysOps;
using Common.Domain;
using FleetManagerServer.Utils.UtilOps;

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

        public void CheckinVehicle(Zaduzenje chk_in)
        {
            CheckinVehicleSO so = new CheckinVehicleSO(chk_in);
            so.ExecuteTemplate();
        }
        public void CheckoutVehicle(Zaduzenje chk_out)
        {
            CheckoutVehicleSO so = new CheckoutVehicleSO(chk_out);
            so.ExecuteTemplate();
        }

        public List<Zaduzenje> GetCheckinsByUser(Korisnik k)
        {
            GetCheckinsByUserSO so = new GetCheckinsByUserSO(k);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Vozilo> GetFreeVehicles()
        {
            GetFreeVehiclesSO so = new GetFreeVehiclesSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Servis> GetAllServices()
        {
            GetAllServicesSO so = new GetAllServicesSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        public void ServiceVehicle(Servisiranje s)
        {
            ServiceVehicleSO so = new ServiceVehicleSO(s);
            so.ExecuteTemplate();
        }
    }
}
