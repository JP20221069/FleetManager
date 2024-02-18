using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagerServer.SysOps
{
    public class GetFreeVehiclesSO :SystemOperation
    {
        public List<Vozilo> Result { get; set; }

        public GetFreeVehiclesSO()
        {
        }

        protected override void ExecuteConcreteOperation()
        {
            this.Result = broker.GetAllFreeVehicles();
        }
    }
}
