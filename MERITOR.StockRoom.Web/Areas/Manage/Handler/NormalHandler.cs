using log4net;
using MERITOR.StockRoom.DomainEntity;
using MERITOR.StockRoom.Business;
using MERITOR.StockRoom.BusinessInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MERITOR.StockRoom.Web.Areas.Manage.Handler
{
    public class NormalHandler : IDIHandler
    {
        private readonly ILog logger = null;
        public NormalHandler()
        {
            logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }
        public string Add(List<EMP> e)
        {
            IDIBusiness busi = new DIBusiness();
            busi.add(e);
            return "NormalHandler";
        }
    }
}