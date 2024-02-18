using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagerServer.SysOps
{
    public class UpdateVehicleSO : SystemOperation
    {
        private readonly Vozilo veh;

        public UpdateVehicleSO(Vozilo veh)
        {
            this.veh = veh;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.UpdateVehicle(veh);
        }
    }
}
