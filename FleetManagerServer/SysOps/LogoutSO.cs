using FleetManagerCommon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagerServer.SysOps
{
    public class LogoutSO : SystemOperation
    {
        private readonly Korisnik user;
        public Korisnik Result { get; set; }

        public LogoutSO(Korisnik user)
        {
            this.user = user;
        }

        protected override void ExecuteConcreteOperation()
        {
            this.Result = broker.Logout(user);
        }
    }
}
