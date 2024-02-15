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
    public class Vozilo :IEntity
    {
        int id;
        string tip;
        string marka;
        int status;
        string regbroj;
        string naziv;
        float nosivost;

        public int ID { get => id; set => id = value; }
        public string Tip { get => tip; set => tip = value; }
        public string Marka { get => marka; set => marka = value; }
        public int Status { get => status; set => status = value; }
        public string RegBroj { get => regbroj; set => regbroj = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public float Nosivost { get => nosivost; set => nosivost = value; }

        string IEntity.TableName => "VOZILO";

        string IEntity.Values => $"'{Tip}'" + $",'{Marka}'" + $",{Status}" + $",'{RegBroj}'" + $",'{Naziv}'" + $",{Nosivost}";

        List<IEntity> IEntity.GetReaderList(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public Vozilo()
        {
            
        }

        public Vozilo(int id, string tip, string marka, int status, string regbroj, string naziv, float nosivost)
        {
            this.id = id;
            this.tip = tip;
            this.marka = marka;
            this.status = status;
            this.regbroj = regbroj;
            this.naziv = naziv;
            this.nosivost = nosivost;
        }
    }
}
