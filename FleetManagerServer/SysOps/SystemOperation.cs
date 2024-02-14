using FleetManagerServer.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagerServer.SysOps
{
    public abstract class SystemOperation
    {
        protected DatabaseBroker broker;

        public SystemOperation()
        {
            broker = new DatabaseBroker();
        }


        public void ExecuteTemplate()
        {
            try
            {
                broker.OpenConnection();
                broker.BeginTransaction();

                ExecuteConcreteOperation();

                broker.Commit();
            }
            catch (Exception ex)
            {
                broker.Rollback();
                throw ex;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        protected abstract void ExecuteConcreteOperation();
    }
}
