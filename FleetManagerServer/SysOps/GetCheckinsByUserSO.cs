using Common.Domain;
using FleetManagerCommon.Domain;
using FleetManagerServer.DB;
using FleetManagerServer.SysOps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagerServer.Utils.UtilOps
{
    public class GetCheckinsByUserSO : SystemOperation
    {
        private Korisnik korisnik;
        public List<Zaduzenje> Result { get; set; }
        public GetCheckinsByUserSO(Korisnik k)
        {
            this.korisnik = k;
        }
        protected override void ExecuteConcreteOperation()
        {
            this.Result=broker.GetCheckinsByUser(korisnik, true);
        }
    }
}
