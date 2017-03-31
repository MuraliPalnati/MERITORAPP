using MERITOR.StockRoom.DataAccessInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MERITOR.StockRoom.DomainEntity;
using MERITOR.StockRoom.DataEntity;
using MERITOR.StockRoom.DataAccess.Generic;
using System.Net;
using MERITOR.StockRoom.Util;

namespace MERITOR.StockRoom.DataAccess
{
    public class SqlServerDataAccess : BaseDataAccess, IDIDataAccess
    {
        public List<EMP> Add(List<EMP> es)
        {
            return es;
        }

        public List<EMP> select(EMP es)
        {
            try
            {
                getDbEntity("Oracle");
                var resp = oracleDBentities.Database.SqlQuery<EMPLOYEE>("SELECT * FROM EMPLOYEE").ToList<EMPLOYEE>();
                var response = GenericAutoMapper<EMPLOYEE, EMP>.listObjectMapper(resp);
                oracleDBentities.Dispose();
                return response;

                /*string query = "SELECT* FROM EMPLOYEE";
                GenericRepository<EMPLOYEE> a = new GenericRepository<EMPLOYEE>();
                var resp = a.selectNativeQuery(query);*/
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
