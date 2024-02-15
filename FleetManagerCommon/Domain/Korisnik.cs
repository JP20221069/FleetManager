using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagerCommon.Domain
{
    [Serializable]
    public class Korisnik
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public int Rola {  get; set; }

        public bool LoggedIn { get; set; }

    }
}
