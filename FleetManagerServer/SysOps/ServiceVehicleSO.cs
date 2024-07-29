using Common.Domain;
using FleetManagerCommon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagerServer.SysOps
{
    public class ServiceVehicleSO : SystemOperation
    {
        private readonly Servisiranje servisiranje;
        public Korisnik Result { get; set; }

        public ServiceVehicleSO(Servisiranje s)
        {
            this.servisiranje = s;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.AddServisiranje(servisiranje);
            try
            {
                broker.Commit();
            }
            catch (Exception ex)
            {
                broker.Rollback();
                throw ex;
            }
            Servisiranje se = broker.GetLatestServicing();
            broker.BeginTransaction();
            foreach(StavkaServisiranja s in servisiranje.Stavke)
            {
                s.Servisiranje = se;
                broker.AddStavkaServisiranja(s);
            }
        }
    }
}
