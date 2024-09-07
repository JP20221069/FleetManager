using FleetManagerCommon.Domain;
using FleetManagerCommon.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagerServer.SysOps
{
    public class AddUserSO : SystemOperation
    {
        private readonly Korisnik user;
        public Korisnik Result { get; set; }

        public AddUserSO(Korisnik user)
        {
            this.user = user;
        }

        protected override void ExecuteConcreteOperation()
        {
            if (broker.ChkUsername(user)==false)
            {
                broker.AddUser(user);
            }
            else
            {
                throw new UserAlreadyExistsException();
            }
            
        }
    }
}
