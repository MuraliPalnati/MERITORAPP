using MERITOR.StockRoom.DataAccessInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MERITOR.StockRoom.DomainEntity;

namespace MERITOR.StockRoom.DataAccess
{
    public class OracleDIDataAccess : IDIDataAccess
    {
        public List<EMP> Add(List<EMP> es)
        {
            return es;
        }
    }
}
