using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagerServer.SysOps
{
    public class CheckoutVehicleSO : SystemOperation
    {
        private readonly Zaduzenje chk_out;
        public Vozilo Result { get; set; }

        public CheckoutVehicleSO(Zaduzenje chk_out)
        {
            this.chk_out = chk_out;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.CheckoutVehicle(chk_out);
        }
    }
}
