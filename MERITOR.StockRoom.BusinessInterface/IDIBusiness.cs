using MERITOR.StockRoom.DomainEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MERITOR.StockRoom.BusinessInterface
{
    public interface IDIBusiness
    {
        List<EMP> add(List<EMP> e);
        List<EMP> select(EMP e);
    }
}
