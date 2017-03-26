using log4net;
using MERITOR.StockRoom.DomainEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MERITOR.StockRoom.Web.Areas.Manage.Handler
{
    //public class WebServiceHandler : IDIHandler
    public class WebServiceHandler 
    {
        private readonly ILog logger = null;
        public WebServiceHandler()
        {
            logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }
        public string Add(List<EMP> e)
        {
            DIWebService.DIWebServiceSoapClient client = new DIWebService.DIWebServiceSoapClient();
            client.HelloWorld();
            return "Added";
        }
    }
}