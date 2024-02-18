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
    public class Zaduzenje : IEntity
    {
        int id;
        Vozilo vozilo;
        Korisnik korisnik;
        bool aktivno;
        string relacijaod;
        string relacijado;
        DateTime vremezaduzenja;
        DateTime vremerazduzenja;
        string napomena;

        public string TableName => "ZADUZENJE";

        public string Values => Convert.ToInt32(Aktivno) + "," + Vozilo.ID + "," + Korisnik.ID + $",'{RelacijaOd}'" + $",'{RelacijaDo}'" + $",'{VremeZaduzenja.ToString("yyyy-MM-dd")}'" + (Aktivno == true ? $",'{VremeRazduzenja.ToString("yyyy-MM-dd")}'" : ",NULL") + $",'{Napomena}'";

        public int ID { get => id; set => id = value; }
        public Vozilo Vozilo { get => vozilo; set => vozilo = value; }
        public Korisnik Korisnik { get => korisnik; set => korisnik = value; }
        public bool Aktivno { get => aktivno; set => aktivno = value; }
        public string RelacijaOd { get => relacijaod; set => relacijaod = value; }
        public string RelacijaDo { get => relacijado; set => relacijado = value; }
        public DateTime VremeZaduzenja { get => vremezaduzenja; set => vremezaduzenja = value; }
        public DateTime VremeRazduzenja { get => vremerazduzenja; set => vremerazduzenja = value; }
        public string Napomena { get => napomena; set => napomena = value; }
        public Zaduzenje()
        {

        }

        public Zaduzenje(int id, Vozilo vozilo, Korisnik korisnik, bool aktivno, string relacijaod, string relacijado, DateTime datumzaduzenja, DateTime datumrazduzenja, string napomena = "")
        {
            this.ID = id;
            this.Vozilo = vozilo;
            this.Korisnik = korisnik;
            this.Aktivno = aktivno;
            this.RelacijaOd = relacijaod;
            this.RelacijaDo = relacijado;
            this.VremeZaduzenja = datumzaduzenja;
            this.VremeRazduzenja = datumrazduzenja;
            this.Napomena = napomena;
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
