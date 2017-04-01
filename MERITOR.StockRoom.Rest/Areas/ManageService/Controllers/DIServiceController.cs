using log4net;
using MERITOR.StockRoom.DomainEntity;
using MERITOR.StockRoom.Business;
using MERITOR.StockRoom.BusinessInterface;
using MERITOR.StockRoom.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MERITOR.StockRoom.Rest.Areas.Manage.Controllers
{
    public class DIServiceController : ApiController
    {
        private readonly ILog logger = null;
        private readonly IDIBusiness business;
        public DIServiceController()
        {
            logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            business = new DIBusiness();
        }
        //public DIServiceController(IDIBusiness busi)
        //{
        //    logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //    business = busi;
        //}

        [HttpPost]
        [ActionName("Add")]
        public HttpResponseMessage Add([FromBody]List<EMP> emp)
        {
            try
            {
                logger.Info("Executing MERITOR.StockRoom.Rest.Areas.Manage.Controllers.DIServiceController.Add with request : " + emp);
                //if (emp != null)
                //{
                var response = business.add(emp);
                logger.Info("Response received from MERITOR.StockRoom.Rest.Areas.Manage.Controllers.DIServiceController.Add: " + response);
                return Request.CreateResponse(HttpStatusCode.OK, response);
                //}
                //return null;
            }
            catch (Exception e)
            {
                logger.Error("Error from MERITOR.StockRoom.Rest.Areas.Manage.Controllers.DIServiceController.Add " + e.Message);
                 throw new Exception(e.Message);
            }
        }

        [HttpPost]
        [ActionName("select")]
        public HttpResponseMessage select([FromBody]EMP emp)
        {
            try
            {
                logger.Info("Executing MERITOR.StockRoom.Rest.Areas.Manage.Controllers.DIServiceController.select with request : " + emp);
                //if (emp != null)
                //{
                var response = business.select(emp);
                logger.Info("Response received from MERITOR.StockRoom.Rest.Areas.Manage.Controllers.DIServiceController.select: " + response);
                return Request.CreateResponse(HttpStatusCode.OK, response);
                //}
                //return null;
            }
            catch (Exception e)
            {
                logger.Error("Error from MERITOR.StockRoom.Rest.Areas.Manage.Controllers.DIServiceController.Add " + e.Message);
                 throw new Exception(e.Message);
            }
        }
    }
}
