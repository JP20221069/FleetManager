using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagerServer.SysOps
{
    public class DeleteVehicleSO : SystemOperation
    {
        private readonly Vozilo veh;

        public DeleteVehicleSO(Vozilo veh)
        {
            this.veh = veh;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.DeleteVehicle(veh.ID);
        }
    }
}
