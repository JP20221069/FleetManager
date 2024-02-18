using Common.Domain;
using FleetManagerCommon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagerServer.SysOps
{
    public class SearchVehicleSO : SystemOperation
    {
        private readonly Vozilo veh;
        public List<Vozilo> Result { get; set; }

        public SearchVehicleSO(Vozilo veh)
        {
            this.veh = veh;
        }

        protected override void ExecuteConcreteOperation()
        {
            this.Result=broker.SearchVehicleBy(veh);
        }
    }
}
