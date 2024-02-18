using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagerServer.SysOps
{
    public class CheckinVehicleSO : SystemOperation
    {
        private readonly Zaduzenje chk_in;
        public Vozilo Result { get; set; }

        public CheckinVehicleSO(Zaduzenje chk_in)
        {
            this.chk_in = chk_in;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.CheckinVehicle(chk_in);
        }
    }
}
