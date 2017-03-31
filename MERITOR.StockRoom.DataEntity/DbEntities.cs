using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MERITOR.StockRoom.DataEntity
{
    public partial class OracleDbEntities : DbContext
    {
        public OracleDbEntities(string connString)
            : base(connString)
        {
        }
    }

    public partial class SqlServerDbEntities : DbContext
    {
        public SqlServerDbEntities(string connString)
            : base(connString)
        {
        }
    }
}
