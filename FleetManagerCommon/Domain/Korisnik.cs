using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagerCommon.Domain
{
    [Serializable]
    public class Korisnik : IEntity
    {
        int id;
        string username;
        string password;
        int rola;
        bool logged_in;
        bool aktivan;

        public int ID { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int Rola { get => rola; set => rola = value; }
        public bool LoggedIn { get => logged_in; set => logged_in = value; }

        public bool Aktivan { get => aktivan; set => aktivan = value; }

        public string TableName =>  "KORISNIK";

        public string ColumnNames => "Username,Password,Rola,Ulogovan,Aktivan";

        public string Values => $"'{Username}',"+$"'{Password}'," + $"{Rola}," + $"{Convert.ToInt32(LoggedIn)}," + $"{Convert.ToInt32(Aktivan)}";

        public Korisnik()
        {
            
        }

        public Korisnik(int id, string username, string password, int rola, bool logged_in, bool aktivan)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.rola = rola;
            this.logged_in = logged_in;
            this.aktivan = aktivan;
            
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return username;
        }
    }
}
