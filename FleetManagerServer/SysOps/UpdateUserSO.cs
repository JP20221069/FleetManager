using FleetManagerCommon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetManagerServer.SysOps
{
    public class UpdateUserSO : SystemOperation
    {
        public Korisnik User;
        public Message Result { get; set; }

        public UpdateUserSO(Korisnik usr)
        {
            this.User = usr;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.UpdateUser(User);
        }
    }
}
