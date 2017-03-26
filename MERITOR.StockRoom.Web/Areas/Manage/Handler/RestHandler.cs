using log4net;
using MERITOR.StockRoom.DomainEntity;
using MERITOR.StockRoom.Web.GenericHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MERITOR.StockRoom.Web.Areas.Manage.Handler
{
    public class RestHandler : IDIHandler
    {
        private readonly ILog logger = null;
        public RestHandler()
        {
            logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }
        public string Add(List<EMP> emp)
        {
            logger.Debug("Executing Add handler.");
            string restApiPath = "DIService/Add";
            logger.Info("Invoking Rest API : " + restApiPath + " with Request : " + emp);
            var response = HandlerUtil<EMP>.PostProcessor(restApiPath, emp);
            logger.Info("Response received form Rest API : " + restApiPath + " : " + response);
            return "Added";
        }

        public List<EMP> select(EMP e)
        {
            logger.Debug("Executing Add handler.");
            string restApiPath = "DIService/select";
            logger.Info("Invoking Rest API : " + restApiPath + " with Request : ");
            var response = HandlerUtil<EMP>.RestPostProcessor(restApiPath,e);
            logger.Info("Response received form Rest API : " + restApiPath + " : " + response);
            return response;
        }
    }
}