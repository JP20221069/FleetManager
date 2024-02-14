using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagerServer.SysOps
{
    public class LoginSO : SystemOperation
    {
        private readonly Korisnik user;
        public Korisnik Result { get; set; }

        public LoginSO(Korisnik user)
        {
            this.user = user;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Login(user);
        }
    }
}
