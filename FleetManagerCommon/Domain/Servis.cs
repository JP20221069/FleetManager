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
    public class Servis:IEntity
    {
        int id;
        string naziv;
        string adresa;

        public int ID { get => id; set => id = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public string Adresa { get => adresa; set => adresa = value; }

        string IEntity.TableName => "Servis";

        string IEntity.ColumnNames => "Naziv,Adresa";

        string IEntity.Values => $"'{Naziv}'," + $"'{Adresa}'";

        public Servis()
        {
            
        }

        public Servis(int id, string naziv, string adresa)
        {
            this.id = id;
            this.naziv = naziv;
            this.adresa = adresa;
        }

        List<IEntity> IEntity.GetReaderList(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
