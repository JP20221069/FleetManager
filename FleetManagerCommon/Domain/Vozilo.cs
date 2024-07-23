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
        StatusVozila status;
        string regbroj;
        string naziv;
        float nosivost;

        List<Zaduzenje> zaduzenja;
        List<Servisiranje> servisiranja;

        public int ID { get => id; set => id = value; }
        public string Tip { get => tip; set => tip = value; }
        public string Marka { get => marka; set => marka = value; }
        public StatusVozila Status { get => status; set => status = value; }
        public string RegBroj { get => regbroj; set => regbroj = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public float Nosivost { get => nosivost; set => nosivost = value; }

        public List<Zaduzenje> Zaduzenja { get => zaduzenja; set => zaduzenja = value; }

        public List<Servisiranje> Servisiranja { get => servisiranja; set => servisiranja = value; }

        public string TableName => "VOZILO";

        public string ColumnNames => "Tip,Marka,Status,RegBroj,Naziv,Nosivost";

        public string Values => $"'{Tip}'" + $",'{Marka}'" + $",{(int)Status}" + $",'{RegBroj}'" + $",'{Naziv}'" + $",{Nosivost}";

        List<IEntity> IEntity.GetReaderList(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public Vozilo()
        {
            this.status = StatusVozila.Default;
        }

        public Vozilo(int id, string tip, string marka, StatusVozila status, string regbroj, string naziv, float nosivost,List<Zaduzenje> zaduzenja,List<Servisiranje> servisiranja)
        {
            this.id = id;
            this.tip = tip;
            this.marka = marka;
            this.status = status;
            this.regbroj = regbroj;
            this.naziv = naziv;
            this.nosivost = nosivost;
            this.zaduzenja = zaduzenja;
            this.servisiranja = servisiranja;
        }

        public override string ToString()
        {
            return Marka + " " + Naziv;
        }
    }
}
