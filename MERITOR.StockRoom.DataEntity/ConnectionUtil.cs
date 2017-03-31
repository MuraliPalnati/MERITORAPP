using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MERITOR.StockRoom.DataEntity
{
    public class ConnectionUtil
    {
        public static string GetConnectionString(string dataBase)
        {
            string connString = string.Empty;
            string currentEnvironment = dataBase;

            try
            {
                switch (currentEnvironment)
                {
                    case "Oracle":
                        {
                            connString = ConfigurationManager.ConnectionStrings["OracleDbEntities"].ConnectionString;
                            break;
                        }
                    case "SqlServer":
                        {
                            connString = ConfigurationManager.ConnectionStrings["SqlServerDbEntities"].ConnectionString;
                            break;
                        }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return connString;
        }
    }
}
