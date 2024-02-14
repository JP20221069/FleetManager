using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace FleetManagerServer.DB
{
    public class DatabaseConnection
    {
        private SqlConnection connection;
        private SqlTransaction transaction;

        public DatabaseConnection()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cs_main"].ConnectionString);
        }

        public void OpenConnection()
        {
            connection?.Open();
        }

        public void CloseConnection()
        {
            connection?.Close();
        }

        public void BeginTransaction()
        {
            transaction = connection.BeginTransaction();
        }
        public void Commit()
        {
            transaction?.Commit();
        }
        public void Rollback()
        {
            transaction.Rollback();
        }
        public SqlCommand CreateCommand()
        {
            return new SqlCommand("", connection, transaction);
        }
    }
}
