using FleetManagerCommon.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    [Serializable]
    public class StavkaServisiranja : IEntity
    {
        int id;
        Servis servis;
        string naziv;
        string opis;
        Servisiranje servisiranje;

        public int ID { get => id; set => id = value; }
        public Servis Servis { get => servis; set => servis = value; }
        public string Naziv { get => naziv; set => naziv = value; }

        public string Opis { get => opis; set => opis = value; }

        public Servisiranje Servisiranje { get => servisiranje; set => servisiranje=value; }

        string IEntity.TableName => "STAVKA_SERVISIRANJA";

        string IEntity.Values => Servisiranje.ID+","+Servis.ID + $",'{naziv}'" + $",'{opis}'";

        public StavkaServisiranja()
        {
            
        }

        public StavkaServisiranja(int id, Servis servis,Vozilo vozilo, string Naziv,string Opis)
        {
            this.id = id;
            this.servis = servis;
            this.naziv = naziv;
            this.opis = opis;
        }

        List<IEntity> IEntity.GetReaderList(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
