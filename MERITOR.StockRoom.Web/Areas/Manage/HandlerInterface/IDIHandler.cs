using MERITOR.StockRoom.DomainEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MERITOR.StockRoom.Web.Areas.Manage.Handler
{
    public interface IDIHandler
    {
        string Add(List<EMP> e);
    }
}
