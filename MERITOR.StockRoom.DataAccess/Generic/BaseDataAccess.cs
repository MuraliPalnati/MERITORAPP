using MERITOR.StockRoom.DataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MERITOR.StockRoom.DataAccess.Generic
{
    public abstract class BaseDataAccess : IDisposable
    {

        public static string connectionString = string.Empty;
        public OracleDbEntities oracleDBentities = null;
        public SqlServerDbEntities sqlDBentities = null;

        public void getDbEntity(string dbName)
        {
            connectionString = ConnectionUtil.GetConnectionString(dbName);
            if (dbName == "Oracle")
            {
                oracleDBentities = new OracleDbEntities(connectionString);
            }
            else if (dbName == "SqlServer")
            {
                sqlDBentities = new SqlServerDbEntities(connectionString);
            }
        }

        #region IDisposable Support
        private readonly bool disposedValue = false; // To detect redundant calls

        void IDisposable.Dispose()
        {
          
            oracleDBentities.Dispose();
            sqlDBentities.Dispose();
        }
        #endregion
    }
}
