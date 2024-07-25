using FleetManagerCommon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagerServer.SysOps
{
    public class GetAllUsersSO : SystemOperation
    {
        public List<Korisnik> Result;
        protected override void ExecuteConcreteOperation()
        {
            this.Result=broker.GetAllUsers();
        }
    }
}
