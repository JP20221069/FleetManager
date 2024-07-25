using Common.Domain;
using FleetManagerCommon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagerServer.SysOps
{
    internal class SearchUserSO : SystemOperation
    {
        private readonly Korisnik user;
        public List<Korisnik> Result { get; set; }

        public SearchUserSO(Korisnik user)
        {
            this.user = user;
        }

        protected override void ExecuteConcreteOperation()
        {
            this.Result = broker.SearchUserBy(user);
        }
    }
}
