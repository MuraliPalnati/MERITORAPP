using MERITOR.StockRoom.DomainEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MERITOR.StockRoom.DataAccessInterface
{
    public interface IDIDataAccess
    {
        List<EMP> Add(List<EMP> es);
    }
}
