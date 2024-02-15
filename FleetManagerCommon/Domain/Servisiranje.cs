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
    public class Servisiranje : IEntity
    {
        int id;
        DateTime datum;
        Vozilo vozilo;
        string napomena;
        List<StavkaServisiranja> stavke;


        string IEntity.TableName => "Servisiranje";
        string IEntity.Values => $"{Vozilo.ID}" +$",'{Napomena}'" +$",'{Datum.ToString("yyyy-MM-dd")}'";
        public DateTime Datum { get => datum; set => datum = value; }
        public Vozilo Vozilo { get => vozilo; set => vozilo = value; }
        public string Napomena { get => napomena; set => napomena = value; }
        public int ID { get => id; set => id = value; }

        public List<StavkaServisiranja> Stavke { get => stavke; set => stavke = value; }

        public Servisiranje()
        {
            
        }

        public Servisiranje(int id,List<StavkaServisiranja> stavke,DateTime datum, Vozilo vozilo, string napomena)
        {
            this.id = id;
            this.stavke = stavke;
            this.datum = datum;
            this.vozilo = vozilo;
            this.napomena = napomena;
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
