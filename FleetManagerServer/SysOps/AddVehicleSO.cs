using Common.Domain;
using FleetManagerCommon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagerServer.SysOps
{
    public class AddVehicleSO : SystemOperation
    {
        private readonly Vozilo veh;
        public Vozilo Result { get; set; }

        public AddVehicleSO(Vozilo veh)
        {
            this.veh = veh;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.AddVehicle(veh);
        }
    }
}
