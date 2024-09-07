using Common.Domain;
using Common.Exceptions;
using FleetManagerCommon.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
            if (broker.ActiveVehicleExists(veh) == false)
            {
                broker.AddVehicle(veh);
            }
            else
            {
                throw new ActiveVehicleExistsException();
            }    
        }
    }
}
