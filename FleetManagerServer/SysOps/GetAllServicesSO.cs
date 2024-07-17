using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagerServer.SysOps
{
    public class GetAllServicesSO : SystemOperation
    {
        public List<Servis> Result { get; set; }

        public GetAllServicesSO()
        {
        }

        protected override void ExecuteConcreteOperation()
        {
            this.Result = broker.GetAllServices();
        }
    }
}
