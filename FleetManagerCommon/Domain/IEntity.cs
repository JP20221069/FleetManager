using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagerCommon.Domain
{
    public interface IEntity
    {
        string TableName { get; }
        string Values { get; }

        List<IEntity> GetReaderList(SqlDataReader reader);

    }
}
